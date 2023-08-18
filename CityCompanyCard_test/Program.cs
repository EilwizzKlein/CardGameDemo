using CityCompanyCard_base;
using CityCompanyCard_API;
using CityCompanyCard_base.Mode;
using CityCompanyCard_test;
using CityCompanyCard_API.Card;
using CityCompanyCard_test.unitTest;

//ModeManager  modeManager = new ModeManager();
//Console.WriteLine(new test().cardBO.test);
//Console.WriteLine(ApplicationContext.Instance.BattleZone);
//Console.ReadKey();

//测试1 - 初始化测试
Demo_Init di = new Demo_Init();
Console.WriteLine("开始初始化测试");
Boolean flag = di.Init();
if (flag)
{
    ApplicationContext app = ApplicationContext.Instance;
    foreach (string key in app.BattleZone.Keys)
    {
        Console.WriteLine(key);
    }

    foreach (ICard card in app.GetMainPlayer().hand.cardList)
    {
        Console.WriteLine(card.renderCardBO.name);
    }
    TestHandle.flag = true;
}
//运行单元测试
//testBuff.start();
//testCommand.start();
//testMoveCommand.start();
testGather.start();

while (TestHandle.flag)
{
    string command = Console.ReadLine()!;
    TestHandle.Handle(command);
}
Console.ReadKey();