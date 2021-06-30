using System.IO;
using System.Text.RegularExpressions;

namespace AustralianInterpreter {
    public class Interpreter {
        private string[] Code;
        public string Output;

        public Interpreter(string fileName) {
            Code = File.ReadAllLines(fileName);
        }

        public int Run() {
            int i = 0;
            bool started = false;
            foreach (var line in Code) {
                if (i == 0) {
                    if (line.ToUpper() == "OI MATE" || line.ToUpper() == "G'DAY COBBA") {
                        started = true;
                        continue;
                    } else {
                        Output = "Oi donkey, use OI MATE or G'DAY COBBA at the beginning of the code. Kids these days.";
                        return -1;
                    }
                }

                if (started) {
                    if (line.ToUpper().StartsWith("GET OUT WILL YA")) {
                        return 0;
                    } else if (line.ToUpper().StartsWith("YELL")) {
                        var regex = new Regex(Regex.Escape("YELL"));
                        var toYell = regex.Replace(line, "", 1).Trim();
                        Output += "\n" + toYell;
                    }
                }
            }

            return 0;
        }
    }
}
