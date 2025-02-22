# Quadratic Equation Solver

Application solves a quadratic equation: ax^2 + bx + c = 0,
where a, b, c are real numbers and a ≠ 0.

# How to run project

1. If **.NET 8.0**: is not installed, you can download it from the [official website](https://dotnet.microsoft.com/en-us/download)

2. Check .NET version:
   ```bash
   dotnet --version
   
3. Use next commands to add project:
   ```bash
   git clone https://github.com/Ruslan-Vladyslav/QuadraticEquationSolver.git
   cd QuadraticEquationSolver
4. Use the command to assemble the project:
   ```bash
   dotnet build EquationSolver.csproj
5. After a successful build, run the project:
    ```bash
   dotnet run
   ```
   Or you can use:
   ```bash
   dotnet run --project EquationSolver.csproj

# How to run in non-interactive mode
  To run program in this mode, need .txt file with three arguments divided by space. Use next commands:
  ```bash
  echo "<argument1> <argument2> <argument3>" > <filename>.txt
  ```
  After creating file run next command:
  ```bash
  dotnet run "<filename>.txt"
  ```

 # Revert commit: [Commit a29a724](https://github.com/Ruslan-Vladyslav/QuadraticEquationSolver/commit/a29a72401460ca45cc96c49fd1efba8488e951a5)


