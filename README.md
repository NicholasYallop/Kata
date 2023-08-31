# Reasoning
Escape clause to handle ""  
Followed by delimiter assignment (for multiple delimiters, replace them all for a pre-defined delimiter)  
Split on delimiters  
Parse each segement as integer  
Handle each integer (e.g. negatives, >1000, sum total)  
Assess how many negatives were found  
If 1 or more negatives, throw error  
Else return sum  

# Structure
Class library to contain StringCalculator class  
NUnit test project to contain test cases  
 -> one test method, many tast cases  
