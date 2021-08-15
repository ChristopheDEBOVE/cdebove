using Microsoft.JSInterop;

namespace christophedebove
{
    public class KeyBoard
    {
        [JSInvokable]
        public void CurrentKeyDown(string KeyCode)
        {
            CurrentDirection = Direction.North;
            if(KeyCode == "ArrowLeft")
                CurrentDirection = Direction.West;
            if(KeyCode == "ArrowRight")
                CurrentDirection = Direction.East;
            if(KeyCode == "ArrowUp")
                CurrentDirection = Direction.North;
            if(KeyCode == "ArrowDown")
                CurrentDirection = Direction.South;
        }
    
        public Direction CurrentDirection { get; private set; } = Direction.East;
        
    }
}