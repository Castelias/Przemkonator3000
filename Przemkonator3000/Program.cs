using Przemkonator3000;

string logo = "  _____                        _                     _            ____   ___   ___   ___  \r\n |  __ \\                      | |                   | |          |___ \\ / _ \\ / _ \\ / _ \\ \r\n | |__) | __ _______ _ __ ___ | | _____  _ __   __ _| |_ ___  _ __ __) | | | | | | | | | |\r\n |  ___/ '__|_  / _ \\ '_ ` _ \\| |/ / _ \\| '_ \\ / _` | __/ _ \\| '__|__ <| | | | | | | | | |\r\n | |   | |   / /  __/ | | | | |   < (_) | | | | (_| | || (_) | |  ___) | |_| | |_| | |_| |\r\n |_|   |_|  /___\\___|_| |_| |_|_|\\_\\___/|_| |_|\\__,_|\\__\\___/|_| |____/ \\___/ \\___/ \\___/ \r\n                                                                                          \r\n                                                                                          ";

Console.WriteLine(logo);

WaitAndExecuteAsync(MainMenu.Run, 5000).Wait();


static async Task WaitAndExecuteAsync(Action action, int delayMilliseconds)
{
    await Task.Delay(delayMilliseconds);
    action();
}
