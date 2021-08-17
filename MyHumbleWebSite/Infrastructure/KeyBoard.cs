using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Microsoft.JSInterop;

namespace MyHumbleWebSite.Infrastructure
{
    public delegate void OnKeyStroked(object sender, KeyBoard.OnKeyStrokedArgs args);

    public class KeyBoard
    {
        public event OnKeyStroked OnKeyStroked;

        [JSInvokable]
        public void CurrentKeyDown(string KeyCode)
        {
            OnKeyStroked?.Invoke(this, new OnKeyStrokedArgs(new Key(KeyCode)));
        }

        public class Key : ValueObject
        {
            private readonly string _keyCode;

            public Key(string keyCode)
            {
                _keyCode = keyCode;
            }

            public static Key ArrowUp => new("ArrowUp");
            public static Key ArrowLeft => new("ArrowLeft");
            public static Key ArrowRight => new("ArrowRight");
            public static Key ArrowDown => new("ArrowDown");
            public static Key Space => new("Space");

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return _keyCode;
            }
        }

        public class OnKeyStrokedArgs
        {
            public OnKeyStrokedArgs(Key key)
            {
                Key = key;
            }

            public Key Key { get; }
        }
    }
}