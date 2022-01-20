using PingPongClient.Abstractions;
using PingPongClient.Common;
using PingPongClient.UI.Abstractions;

namespace PingPongClient
{
    public class PersonObjectProvider : IObjectProvider
    {
        private readonly IInput _input;
        private readonly IOutput _output;

        public PersonObjectProvider(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
        }
        public object Provide()
        {
            _output.Write("Enter Name:");
            var name = _input.GetInput();

            _output.Write("Enter Age:");
            var age = int.Parse(_input.GetInput());

            return new Person(name, age);
        }
    }
}
