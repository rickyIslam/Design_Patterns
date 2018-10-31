using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SOURCE: https://www.codeproject.com/Articles/716413/Factory-Method-Pattern-vs-Abstract-Factory-Pattern

namespace DesignPatterns
{
    public interface IProcessor { void PerformOperation(); }
    public interface IHardDisk { void StoreData(); }
    public interface IMonitor { void DisplayPicture(); }

    public class ExpensiveProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("Operation will perform quickly");
        }
    }
    public class CheapProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("Operation will perform Slowly");
        }
    }

    public class ExpensiveHDD : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("Data will take less time to store");
        }
    }
    public class CheapHDD : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("Data will take more time to store");
        }
    }

    public class HighResolutionMonitor : IMonitor
    {
        public void DisplayPicture()
        {
            Console.WriteLine("Picture quality is Best");
        }
    }
    public class LowResolutionMonitor : IMonitor
    {
        public void DisplayPicture()
        {
            Console.WriteLine("Picture quality is Average");
        }
    }

    // HERE THE DIFFERENCE IS MADE !!! ONE 'MOTHER INTERFACE IS MAPPING ITS CHILD INTERFACE'
    // THIS IS WHY IT IS CALLED 'FACTORY OF FACTORIES'

    public interface IMachineFactory
    {
        IProcessor GetRam();
        IHardDisk GetHardDisk();
        IMonitor GetMonitor();
    }

    public class HighBudgetMachine : IMachineFactory
    {
        public IProcessor GetRam() { return new ExpensiveProcessor(); }
        public IHardDisk GetHardDisk() { return new ExpensiveHDD(); }
        public IMonitor GetMonitor() { return new HighResolutionMonitor(); }
    }
    public class LowBudgetMachine : IMachineFactory
    {
        public IProcessor GetRam() { return new CheapProcessor(); }
        public IHardDisk GetHardDisk() { return new CheapHDD(); }
        public IMonitor GetMonitor() { return new LowResolutionMonitor(); }
    }
    //Let's say in future...Ram in the LowBudgetMachine is decided to upgrade then
    //first make GetRam in LowBudgetMachine Virtual and create new class as follows

    //public class AverageBudgetMachine : LowBudgetMachine
    //{
    //    public override IProcessor GetRam()
    //    {
    //        return new ExpensiveProcessor();
    //    }
    //}

    public class ComputerShop
    {
        IMachineFactory category;
        public ComputerShop(IMachineFactory _category)
        {
            category = _category;
        }
        public void AssembleMachine()
        {
            IProcessor processor = category.GetRam();
            IHardDisk hdd = category.GetHardDisk();
            IMonitor monitor = category.GetMonitor();
            //use all three and create machine

            processor.PerformOperation();
            hdd.StoreData();
            monitor.DisplayPicture();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Client Code
            IMachineFactory factory = new HighBudgetMachine();// Or new LowBudgetMachine();
            ComputerShop shop = new ComputerShop(factory);
            shop.AssembleMachine();
            Console.ReadKey();
        }
    }
}
