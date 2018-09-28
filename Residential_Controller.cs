using System;
using System.Collections.Generic;
using System.Timers;

namespace Rocket_Elevators_Controllers {
    class Program
    {
		
        static void Main(string[] args)
        {
            var elevatorController = new ElevatorController(10, 2);
			var selectedElevator = elevatorController.RequestElevator(1, "Up");


			elevatorController.RequestFloor(selectedElevator, 8);
        }
    }

	class Column {
		public int nbFloor;
		public int nbElevators;
		public List < Elevator > elevatorsList;
		public Column(int nbFloor, int nbElevators) {
			this.nbFloor = nbFloor;
			this.nbElevators = nbElevators;
			List <Elevator> elevatorsList = new List < Elevator > ();
			for (int i = 0; i < this.nbElevators; i++) {
				elevatorsList.Add(new Elevator(i + 1, this.nbFloor));
			}
		}
	}
	class Button {
		public string direction;
		public int requestFloor;
		public Button(string direction, int requestFloor) {
			this.direction = direction;
			this.requestFloor = requestFloor;
		}
	}
	class InsideButton {
		public int floor;
		public string status;
		public InsideButton(int floor) {
			this.floor = floor;
			this.status = "desactivated";
		}
	}
	class ElevatorController {
		public int nbFloor;
		public int nbElevators;
		public List < Button > buttonList;
		public Column column;
		public Elevator selectedElevator;
		public ElevatorController(int nbFloor, int nbElevators) {
			this.nbFloor = nbFloor;
			this.nbElevators = nbElevators;
			this.column = new Column(nbFloor, nbElevators);
		}
		public Elevator RequestElevator(int FloorNumber, string Direction) {
			selectedElevator = this.FindElevator(FloorNumber, Direction);
			selectedElevator.addFloorToList(FloorNumber);
			selectedElevator.activateInsideButton(FloorNumber);
			Console.WriteLine("Request Elevator on floor " + FloorNumber.ToString() + ", going " + Direction);

			return selectedElevator;
		}
		public void RequestFloor(Elevator elevator, int floorNumber) {
			elevator.activateInsideButton(floorNumber);
			elevator.addFloorToList(floorNumber);
			elevator.moveNext();
			Console.WriteLine("Request Floor number " + floorNumber.ToString());
		}
		public Elevator FindElevator(int floorNumber, string direction) {
			int distanceFloor = 999;
			Elevator selectedElevator = null;
			foreach(Elevator elevator in this.column.elevatorsList) {
				int differenceFloor = Math.Abs(floorNumber - elevator.current_floor);
				if (differenceFloor < distanceFloor) {
					distanceFloor = differenceFloor;
					selectedElevator = elevator;
				}
				
				Console.WriteLine("FindElevator " + floorNumber);
				
			}
			return selectedElevator;
		}
		
	}

	class Elevator {
		Timer tmr = new Timer(); 

			public int elevatorNumber;
			public int nbFloor;
			public List<InsideButton> buttonList;			
			public string status;
			public string direction;
			public int current_floor;
			public List<int> floorList;
			public Elevator(int elevatorNumber, int nbFloor) {
				this.elevatorNumber = elevatorNumber;
				this.direction = "NONE";
				this.status = "idle";
				this.floorList = new List<int> ();
				this.buttonList = new List<InsideButton>();
				for (int i = 0; i < nbFloor; i++) {
					buttonList.Add(new InsideButton(i));
				}
			}
			public void moveNext() {
				var FloorNumber = this.floorList[0];
				this.floorList.RemoveAt(0);
				if (this.current_floor > FloorNumber) {
					this.moveDown(FloorNumber);
				}
				else if (this.current_floor < FloorNumber) {
					this.moveUp(FloorNumber);
				}
				else {
					this.OpenDoor();
				}
			}

			public void moveDown(int FloorNumber) {
					tmr.Interval = 1000;
				this.direction = "down";
				this.status = "Moving";
				Console.WriteLine("Elevator is going down");
				do{
					this.current_floor = this.current_floor - 1;
					Console.WriteLine(this.current_floor);
					}
					 while(this.current_floor > FloorNumber);
				Console.WriteLine("Arrived at floor " + this.current_floor);
						this.OpenDoor();
			}
			public void moveUp(int FloorNumber) {
				this.direction = "up";
				this.status = "Moving";
				Console.WriteLine("Elevator is going up");
				
do
{
this.current_floor = this.current_floor + 1;
					Console.WriteLine(this.current_floor);

} while(this.current_floor < FloorNumber);
				Console.WriteLine("Arrived at floor " + this.current_floor);
						this.OpenDoor();
			}
				

			public void addFloorToList(int floorNumber) {
				this.floorList.Add(floorNumber);
				if (this.direction == "up") {
					this.floorList.Sort((a, b) => a.CompareTo(b));
					Console.WriteLine(this.floorList);
					}
				else if (this.direction == "down") {
					this.floorList.Sort((a, b) => -1* a.CompareTo(b));
					Console.WriteLine(this.floorList);
				}
			}

			public void OpenDoor() {
				Console.WriteLine("Opening door on floor " + this.current_floor);
				this.status = "open_door";
				System.Threading.Thread.Sleep(3000);
				this.closeDoor();

			}

			public void closeDoor() {
				Console.WriteLine("Closing door");
				this.status = "close_door";
				if (this.floorList.Count > 0) {
					this.moveNext();
				}
			}

			public void activateInsideButton(int FloorNumber) {
				Console.WriteLine("Activated button at floor " + FloorNumber);

				foreach(InsideButton currentButton in this.buttonList)
				{
					if (currentButton.floor == FloorNumber) {
						currentButton.status = "activated";
					}
				}
			}

			public void deactivateInsideButton(int FloorNumber) {
				Console.WriteLine("Activated button at floor " + FloorNumber);

				foreach(InsideButton currentButton in this.buttonList)
				{
					if (currentButton.floor == FloorNumber) {
						currentButton.status = "deactivated";
					}
				}
			}
		}
}


