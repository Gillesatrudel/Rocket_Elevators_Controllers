using System;
using System.Collections.Generic;
namespace Rocket_Elevators_Controllers {
    class Program
    {
        static void Main(string[] args)
        {
            var elevatorController = new ElevatorController(10, 2);
			elevatorController.RequestElevator(1, "Up");
			elevatorController.RequestFloor(1, "Down");
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
		public int selectedElevator;
		public ElevatorController(int nbFloor, int nbElevators) {
			this.nbFloor = nbFloor;
			this.nbElevators = nbElevators;
			this.column = new Column(nbFloor, nbElevators);
		}
		public void RequestElevator(int FloorNumber, string Direction) {
			selectedElevator = this.FindElevator(FloorNumber);
			selectedElevator = this.addFloorToList(FloorNumber);
			selectedElevator = this.activateInsideButton(FloorNumber);
			Console.WriteLine("Request Elevator on floor " + FloorNumber.ToString() + ", going " + Direction);
		}
		public void RequestFloor(int Elevator, string Direction) {
			Elevator.activateInsideButton(FloorNumber);
			Elevator.addFloorToList(FloorNumber);
			Elevator.moveNext();
			Console.WriteLine("Request Floor number " + FloorNumber.ToString() + ", going " + Direction);
		}
		public void FindElevator(int FloorNumber) {
			int distanceFloor = 999;
			int? selectedElevator = null;
			for (int i = 0; i < this.column.elevatorsList.Count; i++) {
				int differenceFloor = Math.Abs(FloorNumber - this.column.elevatorsList[i].currentFloor);
				if (differenceFloor < distanceFloor) {
					distanceFloor = differenceFloor;
					selectedElevator = this.column.elevatorsList[i];
				}
				return selectedElevator;
				 Console.WriteLine("FindElevator " + FloorNumber);
			}
		}

	}

	class Elevator {
			public int elevatorNumber;
			public int nbFloor;
			public List < Button > buttonList;			
			public string status;
			public string direction;
			public int current_floor;
			public List < floor > floorList;
			public Elevator(int elevatorNumber, int nbFloor) {
				this.elevatorNumber = elevatorNumber;
				this.direction = "NONE";
				this.status = "idle";
				this.floorList = new List < floor > ();
				this.buttonList = buttonList.Add(new Button());
				for (int i = 0; i < nbFloor; i++) {
					buttonList.Add(new Button());
				}
				return current_floor = 1;
			}
			public void move_next() {
				var FloorNumber = this.floorList.Pop();
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
				this.direction = "down";
				this.status = "Moving";
				Console.WriteLine("Elevator is going down");

				var interval = setInterval(() =>{
					this.current_floor = this.current_floor - 1;
					Console.WriteLine(this.current_floor);
					if (this.current_floor == FloorNumber) {
						clearInterval(interval);
						Console.WriteLine("Arrived at floor " + this.current_floor);
						this.OpenDoor();
					}
				},
				1000);
			}
			public void moveUp(int FloorNumber) {
				this.direction = "up";
				this.status = "Moving";
				Console.WriteLine("Elevator is going up");
				var interval = setInterval(() => {
					this.current_floor = this.current_floor + 1;
					Console.WriteLine(this.current_floor);
					if (this.current_floor == FloorNumber) {
						clearInterval(interval);
						Console.WriteLine("Arrived at floor " + this.current_floor);
						this.OpenDoor();
					}
				},
				1000);
			}
			public void addFloorToList(int FloorNumber) {
				this.floorList.Add(FloorNumber);
				if (this.direction == "up") {
					this.floorList.Sort();
					Console.WriteLine(this.floorList);
				}
				else if (this.direction == "down") {
					this.floorList.Sort().reverse();
					Console.WriteLine(this.floorList);
				}
			}

			public void OpenDoor() {
				Console.WriteLine("Opening door on floor " + this.current_floor);
				this.status = "open_door";
				setTimeout(() => {
					this.closeDoor();
				},
				5000);
			}

			public void closeDoor() {
				Console.WriteLine("Closing door");
				this.status = "close_door";
				if (this.floorList.Count() > 0) {
					this.move_next();
				}
			}

			public void activateInsideButton(int FloorNumber) {
				Console.WriteLine("Activated button at floor " + FloorNumber);
				if (this.requestFloor == this.floorList) {
					this.activateInsideButton = false;
				}
				if (this.requestFloor < this.floorList) {
					this.moveUp();
				}
				else if (this.requestFloor > this.floorList) {
					this.moveDown();
				}
			}

		}
}


