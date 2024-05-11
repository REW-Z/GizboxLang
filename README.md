# GizboxLang  

source code: github.com/REW-Z/Gizbox  

# Language Features  

Import Libraries: Uses the import statement to include library files.

Object-Oriented: Supports object-oriented programming but only allows inheritance from a single base class; multiple inheritance is not supported.

Virtual Functions: All member functions are virtual by default.

No Implicit Conversions: There are no implicit conversions (including Liskov substitution); all types require explicit conversion.

Field Initialization: Fields must be initialized with a value upon declaration.

# Other Features  

Properties: Member functions in the form of void xxxx(type arg) and type xxx() are treated as setters and getters respectively.  

# Interoperability  

Interoperation with C#: Interoperability is achieved through external (extern) functions that interface with C#.
