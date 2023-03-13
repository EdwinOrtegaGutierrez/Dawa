import pandas as pd

data = {
    "+": "Addition or concatenation",
    "-": "Subtraction",
    "*": "Multiplication",
    "/": "Division",
    "%": "Modulo",
    "**": "Exponentiation",
    "=": "Assignment",
    "==": "Equality",
    "!=": "Inequality",
    "<": "Less than",
    ">": "Greater than",
    "<=": "Less than or equal to",
    ">=": "Greater than or equal to",
    "and": "Logical 'and' operator",
    "or": "Logical 'or' operator",
    "not": "Logical 'not' operator",
    "is": "Checks if two objects are the same object",
    "in": "Checks if an object is in a sequence",
    "not in": "Checks if an object is not in a sequence",
    "()": "Parentheses (used to call functions and to group expressions)",
    "[]": "Brackets (used to access elements of a list or tuple)",
    "{}": "Braces (used to create dictionaries and sets)",
    ":": "Colon (used in function declarations and loops)",
    ",": "Comma (used to separate elements in a list or tuple)",
    ".": "Dot (used to access attributes of an object)",
    "#": "Comment (used to add comments in the code)"
}

df = pd.DataFrame.from_dict(data, orient='index', columns=['Tabla de simbolos'])

print(df)