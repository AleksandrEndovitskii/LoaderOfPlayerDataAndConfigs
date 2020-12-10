using Models;
using UnityEngine;
using Zenject;

namespace Views
{
    public class TestView : MonoBehaviour
    {
        private ITestModel _testModel;

        [Inject]
        public void Construct(ITestModel testModel)
        {
            _testModel = testModel;
        }

        private void Start()
        {
            Debug.Log(_testModel.TestMessage);
        }
    }
}
