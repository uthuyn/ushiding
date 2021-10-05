# Multi-core parallel algorithms for hiding high-utility sequential patterns

This paper proposes three algorithms named:
1. High Utility Sequential Pattern Hiding Using Pure Array Structure (USHPA)
2. High Utility Sequential Pattern Hiding Using Parallel Strategy(USHP)
3. High Utility Sequential Pattern Hiding Using Random Distribution Strategy (USHR) 

for hiding high-utility sequential patterns on quantitative sequence datasets. 

# How To Run
- Modify the bin/run.bat at your criteria
- Execute run.bat

# Folder Structure
1. bin
  - run.bat
  - USH.exe: built binary executable file
2. data: dir of datasets
3. sanitized: dir where sanitized dataset is written to here
4. hiding-out.txt: hiding results
5. mining-out.txt: mining results
6. hiding-random-out.txt: hinding PF results, when run USHP or USHR with upsilon > 0

# Acknowledgment
This research is funded by Vietnam National Foundation for Science and Technology Development (NAFOSTED) under grant number 102.05-2018.307.

The code is implemented in C# and will be shared soon.
Reports and comments are welcome and can be sent to email: ut.huynhvn@gmail.com
