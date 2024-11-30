using Itmo.ObjectOrientedProgramming.Lab4.Printer;

namespace Itmo.ObjectOrientedProgramming.Lab4.Factories;

public interface IPrinterFactory
{
    string PrinterMode { get; }

    IPrinter CreatePrinter(string fileDesignation, string folderDesignation);

    IPrinter CreatePrinter();
}