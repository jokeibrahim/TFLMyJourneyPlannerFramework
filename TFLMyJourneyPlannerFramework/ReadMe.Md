Each new user is expected to clone this repository from public GitHub. After cloning into visual studio,
all nuget packages need to be restored and the solution can be rebuilt. 

The journey planner test automation framework was built using the followings :
	C# programming language;
	Visual Studio as the IDE;
	Selenium WebDriver as the test automation tool;
	Chrome driver as the main browser for test execution and;
	Specflow for BDD implementation (this makes all scenarios to be written in Gherkin syntax)


Page Object Model was used to manage the structure of the framework as follows :
	All features (e.g. Journey planner) are to be kept within Feature folder;
	Each feature file has it's own step definitions that implement all steps in it;
	Each step definition has multiple functions where each function is implemented using code from page class and;
	Each application module is replicated using a class within the Visual Studio.
	