using Itmo.ObjectOrientedProgramming.Lab4.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public class ConsolePrinterFactory : IPrinterFactory
{
    public string PrinterMode { get; } = "console";

    public IPrinter CreatePrinter(string fileDesignation, string folderDesignation)
    {
        return new ConsolePrinter(fileDesignation, folderDesignation);
    }

    public IPrinter CreatePrinter()
    {
        return new ConsolePrinter();
    }
}