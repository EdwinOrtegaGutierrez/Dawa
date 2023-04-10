using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Compiler
{
    internal class Dawa
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Debe proporcionar un archivo como argumento.");
                return;
            }

            string filename = args[0];

            if (!File.Exists(filename))
            {
                Console.WriteLine("El archivo especificado no existe.");
                return;
            }
            
            Dictionary<string, dynamic> dicVar = new Dictionary<string, dynamic>();
            // Condiciones de datos complejos 
            bool _dic = false;
            bool _tuple = false;
            bool _list = false;
            // Clases de datos complejos
            Dict<string> dict = new();
            List<dynamic> list;
            Tuple tuple;
            // Obtener nombre del diccionario que se crea
            string dicName = "";

            string[] fileContent = File.ReadAllLines(filename);
            foreach (string line in fileContent)
            {
                // Separamos cada parrafo en una lista
                dynamic[] var = line.Split(' ');

                // Leer comentarios
                if (var.Contains("<//") && var.Contains("//>"))
                {
                    var = "".Split(' ');
                }

                // Guardar las variables en un diccionario
                if (var.Length == 3 && var[0].Contains(".") != true && var[1] == "=" && var[2] != "{" && _dic == false && _list == false && _tuple == false)
                {
                    if (var[2].Contains("\""))
                    {
                        Str s = new Str(var[2].Replace("\"", ""));

                        dicVar[var[0]] = s;
                    }
                    else
                    {
                        var[2] = var[2].Replace(";", "");
                        if (var[2] == "false" || var[2] == "true")
                        {
                            if (var[2] == "false")
                            {
                                Bool boolean = new Bool(false);
                                dicVar[var[0]] = boolean;
                            }
                            else
                            {
                                Bool boolean = new Bool(true);
                                dicVar[var[0]] = boolean;
                            }
                        }
                        else
                        {
                            try
                            {
                                int n = int.Parse(var[2]);
                                Integer num = new Integer(n);
                                dicVar[var[0]] = num;
                            }
                            catch
                            {
                                double n = double.Parse(var[2]);
                                Float num = new Float(n);
                                dicVar[var[0]] = num;
                            }
                        }
                    }
                }

                // Aplicar operadores aritmeticos + - * / % **
                if (var.Length > 3 && (var.Contains("*") || var.Contains("+") || var.Contains("-") || var.Contains("/") || var.Contains("%") || var.Contains("**"))) 
                {
                    string operacion = "";
                    string aux = "";
                    foreach (string var2 in var) // Cambiar las variables por el valor almacenado
                    {
                        try
                        {
                            aux = dicVar[var2].ToString();
                            operacion = operacion + aux + " ";
                        } catch {
                            operacion += var2 +" ";
                        }
                    }

                    dynamic result = SplitString(operacion);
                    string nameOperation = result[0];
                    result.RemoveAt(0);
                    result.RemoveAt(0);

                    // Resolver parentesis
                    Stack<object> stack = new Stack<object>();
                    foreach (string item in result)
                    {
                        if (item.Contains(")") == true)
                        {
                            // Cuando se encuentra un paréntesis de cierre, se realiza el cálculo
                            double operand2 = Convert.ToDouble(stack.Pop());
                            string op = (string)stack.Pop();
                            double operand1 = Convert.ToDouble(stack.Pop());
                            double r = PerformOperation(op, operand1, operand2);
                            stack.Pop(); // Elimina el paréntesis de apertura de la pila
                            stack.Push(r);
                        }
                        else
                        {
                            stack.Push(item);
                        }
                    }

                    // Resolver operaciones basicas
                    Stack<string> colaOpe = new Stack<string>();
                    Stack<double> colaNum = new Stack<double>();
                    foreach (dynamic item in stack)
                    {
                        try
                        {
                            try {
                                double n = Convert.ToDouble(item);
                                colaNum.Push(n);
                            } catch {
                                colaOpe.Push(item);
                            }
                        } catch {
                            colaNum.Push(item);
                        }
                    }
                    double rAux = 0;
                    string operation = "";
                    for (int i = 0; i < colaNum.Count; i++) 
                    {
                        if (operation == "")
                        {
                            rAux = colaNum.ElementAt(i);
                            if(i <= colaOpe.Count - 1)
                            {
                                operation = colaOpe.ElementAt(i);
                            }
                        }
                        else
                        {
                            double r = PerformOperation(operation, rAux, colaNum.ElementAt(i));
                            if (i <= colaOpe.Count - 1) {
                                operation = colaOpe.ElementAt(i);
                            }
                            rAux = r;
                        }
                    }
                    dicVar[nameOperation] = rAux;
                }

                // Actualizar datos de un diccionario
                if (var.Length >= 3 && var[0].Contains(".") == true)
                {
                    string dic = var[0].ToString();
                    string[] vv = dic.Split('.');
                    string tagName = vv[0];
                    string tagData = vv[1];
                    if (var[2].Contains("\"") == true)
                    {
                        string s = var[2].ToString();
                        string value = "";
                        // Patrón regular para buscar la cadena dentro de las comillas
                        string pattern = "\"([^\"]*)\"";
                        Match match = Regex.Match(s, pattern);
                        if (match.Success)
                        {
                            value = match.Groups[1].Value;
                        }
                        Str data = new Str(value);
                        dicVar[tagName][tagData] = data;
                    }
                }

                // Crear datos completos (Dic, Tuple, List) y almacenarnos en dicVar
                if (var.Length >= 3)
                {
                    if (var[2] == "{" || _dic == true)
                    {
                        string nameTag = "";
                        if (_dic == false && var[2].Contains("{") == true)
                        {
                            dicName = var[0];
                            _dic = true;
                        }
                        else if (_dic == true)
                        {
                            string s = "";
                            foreach (string s2 in var)
                            {
                                s += s2 + " ";
                            }
                            // Patrón regular para buscar la cadena dentro de las comillas
                            string pattern = "\"([^\"]*)\"";
                            Match match = Regex.Match(s, pattern);
                            if (match.Success)
                            {
                                nameTag = match.Groups[1].Value;
                            }
                            dynamic data = var[2].Replace(",", "");

                            // Preparar el diccionario antes de guardar en memoria
                            try
                            {
                                try
                                {
                                    // Pasar a Bool
                                    if (data.Contains("false") == true)
                                    {
                                        dict.Add(nameTag, new Bool(false));
                                    }
                                    if (data.Contains("true") == true)
                                    {
                                        dict.Add(nameTag, new Bool(true));
                                    }
                                }
                                catch 
                                {}
                                try
                                {
                                    try
                                    {
                                        // Pasar a Integer el data set
                                        Integer num = new Integer(int.Parse(data));
                                        dict.Add(nameTag, num);
                                    }
                                    catch
                                    {
                                        // Pasar a Integer el data set
                                        Float num = new Float(double.Parse(data));
                                        dict.Add(nameTag, num);
                                    }
                                }
                                catch 
                                {                                    
                                    // Pasar a Str
                                    if (data.Contains("\"") == true)
                                    {
                                        Str data_string = new Str(data.Replace("\"", ""));
                                        dict.Add(nameTag, data_string);
                                    }
                                }
                                try
                                {
                                    // Buscar datos en las variables que ya existen
                                    dynamic d = dicVar[data.ToString()];
                                    dict.Add(nameTag, d);
                                } catch {}
                            } catch {}
                        }
                    }
                    if (var[2].Contains("[") == true)
                    {    
                        list = new();
                        string name = "";
                        bool getName = false;
                        foreach (string var2 in var)
                        {
                            if (getName == true)
                            {
                                string v = var2;
                                if (v.Contains("="))
                                {
                                    v = "";
                                }
                                v = v.Replace("[", "");
                                v = v.Replace("]", "");
                                v = v.Replace(",", "");
                                if (v != "")
                                {
                                    // Guardar cada dato en su respectiva clase
                                    try
                                    {
                                        try
                                        {
                                            // Pasar a Bool
                                            if (v.Contains("false") == true)
                                            {
                                                list.Add(new Bool(false));
                                            }
                                            if (v.Contains("true") == true)
                                            {
                                                list.Add(new Bool(true));
                                            }
                                        } catch {}
                                        try
                                        {
                                            try
                                            {
                                                // Pasar a Integer el data set
                                                Integer num = new Integer(int.Parse(v));
                                                list.Add(num);
                                            }
                                            catch
                                            {
                                                // Pasar a Integer el data set
                                                Float num = new Float(double.Parse(v));
                                                list.Add(num);
                                            }
                                        } catch {}
                                        try
                                        {
                                            // Buscar datos en las variables que ya existen
                                            dynamic d = dicVar[v.ToString()];
                                            list.Add(d);
                                        }
                                        catch { }
                                        finally {
                                            try
                                            {
                                                if (v.Contains("\"") == true)
                                                {
                                                    v = v.Replace("\"", "");
                                                    // Pasar a Str                                            
                                                    Str data_string = new Str(v);
                                                    list.Add(data_string);
                                                }
                                            } catch { }   
                                        }
                                    }
                                    catch { }
                                }
                            }
                            if (getName == false)
                            {
                                name = var2;
                                getName = true;
                            }
                        }
                        dicVar[name] = list;
                    }
                    if (var[2].Contains("(") == true && var[2].Contains(",") == true) 
                    {
                        // Extraer datos y guardarlos en una pila 
                        string tagName = "";
                        List<dynamic> listT = new();
                        dynamic data;
                        foreach (dynamic var2 in var)
                        {
                            listT.Add(var2.Replace(",", ""));
                        }
                        tagName = listT[0].ToString();
                        listT.RemoveAt(0);
                        listT.RemoveAt(0);
                        data = listT[0].ToString();
                        listT[0] = data.Replace("(", "");
                        data = listT[^1].ToString();
                        listT[^1] = data.Replace(")", "");

                        // Convertir datos a las clases Dawa para poder almacenarlos en DicVar
                        int contador = 0; 
                        foreach (dynamic var3 in listT)
                        {
                            data = var3.ToString();
                            // Actualizar la lista con los datos que corresponde
                            try
                            {
                                if (data.Contains("\"") == true)
                                {
                                    data = data.Replace("\"", "");
                                    Str str = new(data);
                                    contador += 1;
                                    listT[contador-1] = str;
                                }
                                else
                                {
                                    Bool boolean = new(bool.Parse(data));
                                    contador += 1;
                                    listT[contador-1] = boolean;
                                }
                            } catch {
                                try
                                {
                                    Integer integer = new(int.Parse(data));
                                    contador += 1;
                                    listT[contador-1] = integer;
                                } catch {
                                    Float _float = new(double.Parse(data));
                                    contador += 1;
                                    listT[contador-1] = _float;
                                }
                            }
                        }
                        // Inicializar la tupla
                        tuple = new Tuple(listT.ToArray());
                        dicVar[tagName] = tuple;
                    }
                }

                // Cerrar diccionario
                if (var[0] == "}" || var[0] == "]" || var[0] == ")")
                {
                    if (var[0] == "}")
                    {
                        _dic = false;
                        dicVar[dicName] = dict;
                        dicName = "";
                    }
                }

                // No va a imprimir hasta que termine de almacenar los datos complejos 
                if (_dic == false || _list == false || _tuple == false)
                {
                    // println(name);
                    if (var[0].Contains("println") == true)
                    {
                        // Busca una comilla " para capturar el interior: "hello world" -> hello world
                        if (var[0].Contains("\"") == true)
                        {
                            string s = "";
                            string value = "";
                            foreach (string s2 in var)
                            {
                                s += s2 + " ";
                            }
                            // Patrón regular para buscar la cadena dentro de las comillas
                            string pattern = "\"([^\"]*)\"";
                            Match match = Regex.Match(s, pattern);
                            if (match.Success)
                            {
                                value = match.Groups[1].Value;
                            }
                            if (value.Contains("{") == true && value.Contains("}") == true)
                            {
                                string p = @"{(.+?)}"; // Expresión regular para buscar el texto dentro de las llaves {}
                                MatchCollection matches = Regex.Matches(value, p);

                                // Imprimir cada match encontrado
                                foreach (Match m in matches)
                                {
                                    string v = m.Groups[1].Value;

                                    // Evaluar consulta [index]
                                    if (v.Contains("[") == true && v.Contains("]") == true)
                                    {
                                        string[] ss = v.Split("[");
                                        ss[1] = ss[1].Replace("]", "");
                                        int n = int.Parse(ss[1]);
                                        string b = dicVar[ss[0]][n].ToString();
                                        string r = "{" + v + "}";
                                        string message = value.Replace(r, b);
                                        Console.WriteLine(message);
                                    }

                                    else if (v.Contains(".") == true) // Se imprime el diccionario y el contenido de su tag
                                    {
                                        string[] vv = v.Split('.');
                                        string tagName = vv[0];
                                        string tagData = vv[1];
                                        string b = dicVar[tagName][tagData].ToString();
                                        string r = "{" + v + "}";
                                        string message = value.Replace(r, b);
                                        Console.WriteLine(message);
                                    }
                                    else // Se imprime una variable simple
                                    {
                                        string newV = dicVar[v].ToString();
                                        string r = "{" + v + "}";
                                        string message = value.Replace(r, newV);
                                        Console.WriteLine(message);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(value);
                            }
                        }
                        else
                        {
                            var[0] = var[0].Replace("println", "");
                            var[0] = var[0].Replace(";", "");
                            var[0] = var[0].Replace("(", "");
                            var[0] = var[0].Replace(")", "");
                            string s = var[0];
                            // Evaluar consulta [index]
                            if (s.Contains("[") == true && s.Contains("]") == true)
                            {
                                string[] ss = s.Split("[");
                                ss[1] = ss[1].Replace("]", "");
                                int n = int.Parse(ss[1]);
                                Console.WriteLine(dicVar[ss[0]][n]);
                            }
                            else if (s.Contains(".") == true) // Se imprime el diccionario y el contenido de su tag
                            {
                                string[] vv = s.Split('.');
                                string tagName = vv[0];
                                string tagData = vv[1];
                                string b = dicVar[tagName][tagData].ToString();
                                Console.WriteLine(b);
                            }
                            else {
                                Console.WriteLine(dicVar[s]);
                            }
                        }
                    }
                }
            }
        }

        public static List<string> SplitString(string input)
        {
            List<string> tokens = new List<string>();
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if(word.Contains("(") == true || word.Contains(")") == true)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        tokens.Add(word[i].ToString());
                    }
                }
                else {
                    tokens.Add(word);
                }
            }

            if (tokens.Last() == ";")
            {
                tokens.RemoveAt(tokens.Count - 1);
            }
            return tokens;
        }

        
        static double PerformOperation(string op, double operand1, double operand2)
        {
            switch (op)
            {
                case "+":
                    return Operator.Add(operand1, operand2);
                case "-":
                    return Operator.Subtract(operand1, operand2);
                case "*":
                    return Operator.Multiply(operand1, operand2);
                case "/":
                    return Operator.Divide(operand1, operand2);
                case "%":
                    return Operator.Modulus(operand1, operand2);
                case "**":
                    return Operator.Exponentiation(operand1, operand2);
                default:
                    throw new ArgumentException("Operador no válido: " + op);
            }
        }
    }
}
