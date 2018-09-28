using System;
namespace demoApp 
{
    class Column
   {
       private int nbFloor;
       private int nbElevators;

        for(var i = 0; i < this.nbElevator; i++)
            var elevator = new

       public Column (int nbFloor, int nbElevators)
       {
           this.nbFloor = nbFloor;
           this.nbElevators = nbElevators;
           this.elevatorList = [];

       }
   }
   class Button
   {
      private int direction;
      private int request_floor

      public Button (int direction, int request_floor)
      {
          this.direction = direction;
          this.request_floor = request_floor;
          this.activate_button = false;
      }
   }


   class InsideButton
   {
      private int floor;
      public InsideButton (int floor)
      {
          this.floor = floor;
          this.status = 'desactivated';
      }
   }


    class ElevatorController 
    {
        private int nbFloor;
        private int nbElevators; 
        
        public ElevatorController(int nbFloor, int nbElevators) 
        {
            this.nbFloor = nbFloor;
            this.nbElevators = nbElevators;
           
        }
        public void RequestElevator(int FloorNumber, string Direction) 
        {
            Console.WriteLine("Request Elevator on floor " + FloorNumber.ToString() + ", going " + Direction);
        }
        public void RequestFloor(int FloorNumber, string Direction) 
        {
            Console.WriteLine("Request Floor number " + FloorNumber.ToString() + ", going " + Direction);
        }
        public void FindElevator(int FloorNumber, string Direction)

            var = distanceFloor = 999;
            var selectedElevator = null;
            for(int i = 0; i< this.column.elevatorList.lenght; i++)
            var differenceFloor = Math.abs(FloorNumber - this.column.elevatorList[i].currentFloor);
        
            if(differenceFloor < distanceFloor)
                distanceFloor = differenceFloor;
                selectedElevator = this.column.elevatorList[i]
            return selectedElevator;

        {
            Console.WriteLine("FindElevator " + FloorNumber.ToString() + ", going " + direction);
        } 

    }

    class Elevator
    {
        private int elevatorNumber;
        private int numberOfFloor;

         for ( int i = 0; i < nbFloor; i++) 
            {
                Console.WriteLine(this.buttonList.push(new insideButton(i)));
            }  
                get{ return currentFloor = 1; }
            

        public void MoveNext()

            let floorList = new floorList
            let FloorNumber = new
        {
            Console.WriteLine("MoveNext")
        }
        public void MoveDown(int FloorNumber )
        {
            Console.WriteLine("MoveDown" + FloorNumber.ToString() )
        }
        public void MoveUp(int FloorNumber )
        {
            Console.WriteLine("MoveUp"+ FloorNumber.ToString)
        }
        public void addFloorToList(int FloorNumber)
        {
          Console.WriteLine("addFloorToList" + FloorNumber.ToString() );
        }
        public void OpenDoor()
        {
          Console.WriteLine("OpenDoor");
        }
        public void CloseDoor()
        {
          Console.WriteLine("CloseDoor");
        }
        public void activateInsideButton(int FloorNumber)
        {
          Console.WriteLine("activateInsideButton" + FloorNumber.ToString() );
        }


        
    }
}