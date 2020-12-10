namespace Models
{
    public class TestModel: ITestModel
    {
        public string TestMessage => _testMessage;

        private string _testMessage = "TestMessage";
    }
}