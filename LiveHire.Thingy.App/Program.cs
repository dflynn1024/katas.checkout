using System;

namespace LiveHire.Thingy.App
{
    internal class Program
    {
        private static int Main()
        {
            try
            {
                Output("LiveHire Thingy v0.1 (beta)", OutputType.Title);

                Prompt("Press any key to continue...");

                return Exit();
            }
            catch (Exception e)
            {
                GlobalErrorHandler(e);
                return Exit(ExitCode.Fail);
            }
        }

        #region Private Helpers

        private static void Output(string message, OutputType outputType = OutputType.Info, bool newLine = true)
        {
            SetupColours(outputType);

            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
        }

        private static string Prompt(string prompt)
        {
            Output(prompt, OutputType.Prompt, false);
            return Console.ReadLine();
        }

        private static int PromptNumber(string prompt)
        {
            while (true)
            {
                var input = Prompt(prompt);

                if (uint.TryParse(input, out var number))
                    return (int)number;
            }
        }

        public static void SetupColours(OutputType outputType = OutputType.Info)
        {
            switch (outputType)
            {
                case OutputType.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case OutputType.Warning:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case OutputType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case OutputType.Prompt:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case OutputType.Title:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
        }

        private static int Exit(ExitCode exitCode = ExitCode.Success)
        {
            Console.ResetColor();
            return (int)exitCode;
        }

        private static void GlobalErrorHandler(Exception e)
        {
            Output($"Exception: {e.Message}\nSource: {e.Source}\nStack Trace: {e.StackTrace}", OutputType.Error);
        }

        #endregion
    }
}
