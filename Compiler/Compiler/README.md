## Eduardo
**Integer**
```
// Create integer
Integer num = new Integer(1);
Integer num2 = new Integer(2);
int result = Operator.Add(num.GetValue(),num2.GetValue());

Console.WriteLine(result);
```

**Float**
```
// Create float
Float num = new Float(45.094);
Float num2 = new Float(2.40000000000003);
double result = Operator.Add(num.GetValue(),num2.GetValue());

Console.WriteLine(result);
```

**Bool**
```
// Create bool
Bool boolean = new Bool(false);
Console.WriteLine(boolean);

// Change value
boolean = new Bool(true);
Console.WriteLine(boolean);
```

## Edwin
**String**
```
// Create string
Str str = new Str("hello world");

// Output
Console.WriteLine(str); // hello world

// Lenght of string
Console.WriteLine(str.Length); // output: 11

// Get char at a coordinate
Console.WriteLine(str[0]); // output: h

// Output of Lenght
Console.WriteLine(str.Substring(6)); // output: world
Console.WriteLine(str.Substring(0, 5)); // output: hello

// Contains
Console.WriteLine(str.Contains("w"));

// Replace
Console.WriteLine(str.Replace("world", "everyone")); // output: hello everyone
```

**Tuple**
```
// Create tuple
Tuple tuple = new Tuple(1, "hello", 3.14, true);

// Output
Console.WriteLine(tuple);

//print each element
for (int i = 0; i < tuple.Count; i++)
{
    Console.WriteLine(tuple[i]);
}

// Print index element
Console.WriteLine(tuple[2]);
```

**List**
```
// Create list
List<dynamic> list = new() 
{
	"red",
	"white",
	"blue",
	1,
	34.2,
	false
};

Console.WriteLine(list);

// Add
list.Add(2);
Console.WriteLine(list);

// Contains
Console.WriteLine(list.Contains("red")); // True
Console.WriteLine(list.Contains("eddy")); // False

// Insert
list.Insert(3, "eddy");
Console.WriteLine(list);

// Remove
list.Remove("eddy");
Console.WriteLine(list);

// RemoveAt
list.RemoveAt(2);
Console.WriteLine(list);

// Index Of each element
Console.WriteLine(list.IndexOf("blue"));

// Count
Console.WriteLine(list.Count);

// Get variable at a coordinate
Console.WriteLine(list[5]);
```

**Operator**: Numeric operators.
Functions:
	* Add: ```+```
	* Subtract: ```-```
	* Multiply: ```*```
	* Divice: ```/```
	* Modulus: ```%```
	* Exponentiation: ```**```

```
dynamic result1 = Operator.Add(1, 2);
dynamic result2 = Operator.Add(2, 35);
dynamic result3 = Operator.Add(23.32, 3.45000000006);
```

**Dictionary**: Usage of the Dict class.
```
List<dynamic> list = new()
{
    "red",
    "white",
    "blue",
    1,
    34.2
};


Dict<string> dict = new();

dict.Add("brand", "Ford");
dict.Add("electric", false);
dict.Add("year", 1964);
dict.Add("list", list);

Console.WriteLine(dict["brand"]);    // Output: Ford
Console.WriteLine(dict["electric"]); // Output: False
Console.WriteLine(dict["year"]);     // Output: 1964
Console.WriteLine(dict["list"]);     // Salida de la lista
Console.WriteLine(dict["list"][0]); // Elemento de la lista


dict["year"] = 2002;
Console.WriteLine(dict["year"]); // Output: 2002

Console.WriteLine(dict.ContainsKey("electric")); // Output: True

dict.Remove("orange");
Console.WriteLine(dict.ContainsKey("orange")); // Output: False

Console.WriteLine(dict.Count); // Output: 4
```

## How to program in Dawa
```
println("Hello World");

name = "Eddy"
println(name);

age = 20
println("Age: {age} years old");

money = 350.48
println("Money: {money} dollars")

handsome = true;
println("Handsome: {handsome}")

<// This is a comment //>
data = {
	"id" : 1,
	"nationality" : "american",
	"name" : name,
	"age" : age,
	"money" : money,
	"handsome" : handsome,
	"height" : 1.65,
	"becario" : false
}

println("Information: {data}");
println("Name: {data.name}");
data.name = "Omar"
println("Name: {data.name}")
println(data.age)

countrys = ["Mexico", "USA", "Canada", 2, 23.32, true]

println("Countrys: {countrys}");
println(countrys[0]);
println("Countrys: {countrys[0]}")

salaryDay = 300

month = 31;

monthlySalary = salaryDay * month - (1 / 2) - (3 / 4);

println(monthlySalary);

keys = (234, 343.443, "djjdjs", false)

println(keys)
println(keys[0])
```


## TODO
* Try & catch.
* For, foreach, while, do while.
* If, else, else if.
* List on list, tuple on list, list and tuple on dic.
* Improve arithmetic operation calculation, improve compiler code.