using System;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace scharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetAllCalendarItems();
        }
        
        static void GetAllCalendarItems()
        {
            Microsoft.Office.Interop.Outlook.Application oApp = null;
            Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
            Microsoft.Office.Interop.Outlook.Items outlookCalendarItems = null;

            oApp = new Microsoft.Office.Interop.Outlook.Application();
            mapiNamespace = oApp.GetNamespace("MAPI"); ;
            CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
            outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = false;

            foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
            {
                if (item.IsRecurring)
                {
                    // maybe get instance 
                    Microsoft.Office.Interop.Outlook.RecurrencePattern rp = item.GetRecurrencePattern();
                    DateTime first = new DateTime(2021, 8, 31, item.Start.Hour, item.Start.Minute, 0);
                    DateTime last = new DateTime(2021, 10, 1);
                    Microsoft.Office.Interop.Outlook.AppointmentItem recur = null;
                    for (DateTime cur = first; cur <= last; cur = cur.AddDays(1))
                    {
                        try
                        {
                            recur = rp.GetOccurrence(cur);
                            Console.WriteLine(recur.Subject + " -> " + cur.ToLongDateString());
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    //Console.WriteLine(item.Subject + " -> " + item.Start.ToLongDateString());
                }
            }
        }
    }
    
}

namespace System.Runtime.InteropServices
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class NativeCallableAttribute : Attribute
    {
        public string EntryPoint;
        public CallingConvention CallingConvention;
        public NativeCallableAttribute() { }
        
        [NativeCallable(EntryPoint = "add_dotnet", CallingConvention = CallingConvention.Cdecl)]
        public static int Add(int a, int b) {
            return a + b;
        }
    }
}

