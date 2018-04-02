using System;
using Xbehave;

namespace Soat.CleanCode.VideoStore.OutsideIn.Tests.Dsl
{
    public class Bdd
    {
        public static AfterGiven Given(string text, Action body)
        {
            Step("Given", text, body);
            return new AfterGiven();
        }

        public class AfterGiven
        {
            public AfterGiven And_(string text, Action body)
            {
                Step("  And", text, body);
                return new AfterGiven();
            }

            public AfterWhen When(string text, Action body)
            {
                Step("When", text, body);
                return new AfterWhen();
            }
        }

        public class AfterWhen
        {
            public AfterWhen And(string text, Action body)
            {
                Step(" And", text, body);
                return new AfterWhen();
            }

            public AfterThen Then(string text, Action body)
            {
                Step("Then", text, body);
                return new AfterThen();
            }
        }

        public class AfterThen
        {
            public AfterThen And_(string text, Action body)
            {
                Step(" And", text, body);
                return new AfterThen();
            }
        }

        private static void Step(string prefix, string text, Action body)
        {
            $"{prefix} {text}".x(body);
        }
    }
}
