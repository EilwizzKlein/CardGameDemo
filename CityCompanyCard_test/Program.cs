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

//选择完整测试


//测试1 - 初始化测试

//测试2 - 单元测试
ITest test = new Demo_Init();
test.runTest();