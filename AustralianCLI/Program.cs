using System;
using AustralianInterpreter;

namespace AustralianCLI {
    class Program {
        static int Main(string[] args) {
            string file;
            try {
                file = args[0];
            } catch (IndexOutOfRangeException) {
                Console.WriteLine("No filename provided.");
                return -1;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return -1;
            }
            Interpreter interpreter = new Interpreter(file);
            interpreter.Run();
            Console.WriteLine(interpreter.Output);
            return 0;
        }
    }
}
