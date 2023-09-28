using System.Text;

Console.WriteLine("CW 43");

var filePath = "/Users/azamamonov/RiderProjects/dotNET_Level_i-2/ClassWork_I_2/ClassWork_43/solo.txt";
var mutex = new Mutex(false, "OpenFileMutex");

var task = Task.Run(() =>
{
    mutex.WaitOne();
    var guid = Guid.NewGuid();

    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
    Console.WriteLine($"App {guid} opened the file ");

    // Write template
    var emailTemplate = "Text from TEST project";
    fileStream.Write(buffer: Encoding.UTF8.GetBytes(emailTemplate));

    Thread.Sleep(3_000);

    fileStream.Close();
    Console.WriteLine($"File {guid} closed successfully");
    mutex.ReleaseMutex();

});
await task;
await Task.Delay(1000);