namespace Epam.NetMentoring.Config
{
    class Program
    {
        static void Main(string[] args)
        {
       //    var t= new ConfigReader("Devd.txt");
       //     var b = new Builder<Service>();
       //     var d = b.ResolvedClass;

            var obj = new ConfigProvider(new ConfigFile("../../Content/Dev.txt"));
           var resolved= obj.Resolve<Service>();


        }
    }
}
