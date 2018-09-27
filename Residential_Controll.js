class Column {
    constructor(number_of_floor, number_of_elevator){
      this.number_of_floor = number_of_floor;
      this.number_of_elevator = number_of_elevator;
      this.elevatorList = [];


      for (let i = 0; i < this.number_of_elevator; i++) {
             let elevator = new Elevator(i+1,number_of_floor)
             this.elevatorList.push(elevator);
        }
    }
}
class Button{
    constructor (direction, request_floor) {
        this.direction = direction;
        this.request_floor = request_floor;
        this.activate_button = false;
    }
}

class InsideButton{
    constructor (floor) {
        this.floor = floor;
        this.status = "desctivated";

    }
}
class ElevatorController {
    constructor(number_of_floor, number_of_elevator) {
      this.number_of_floor = number_of_floor;
      this.number_of_elevator = number_of_elevator;
      this.column = new Column(number_of_floor, number_of_elevator);
      this.button_list = [new Button()];

    }


    RequestElevator(floor_number, direction) {
        var selected_elevator = this.FindElevator(floor_number, direction);
        selected_elevator.addFloorToList(floor_number);
        selected_elevator.activateInsideButton(floor_number);
    }


    RequestFloor(elevator, floor_number) {
        elevator.activateInsideButton(floor_number);
        elevator.addFloorToList(floor_number);
        elevator.move_next();

    }
    FindElevator(FloorNumber, direction) {
        var distance_floor = 999;
        var selected_elevator = null;
        for (var i = 0; i < this.column.elevatorList.length; i++) {
          var difference_floor = Math.abs(FloorNumber - this.column.elevatorList[i].current_floor);
            if (difference_floor < distance_floor) {
              distance_floor = difference_floor;
              selected_elevator =  this.column.elevatorList[i];
            }
           // IF Floor = Elevator.CurrentFloor AND Status = Stopped OR ElevatorDirection = Direction THEN
           //if (floor_number === this.column.elevatorList[i].CurrentFloor && this.column.elevatorList[i].status === "idle" && this.column.elevatorList[i].direction === direction) {
               //return this.elevatorList[i]
           //}
           //console.log(this.column.elevatorList[i].status)
       }
       return selected_elevator;
    }
}

class Elevator {
    constructor(elevator_number, number_of_floor) {
        this.elevator_number = elevator_number;
        this.direction = "NONE";
        this.status = "idle";
        this.floor_list = [];
        this.button_list = [];
        for (var i = 0; i < number_of_floor; i++) {
            this.button_list.push(new InsideButton(i));
        }
        this.current_floor = 1;
    }
    move_next(){
        let floor_list = this.floor_list
        let floor_number = floor_list.shift();
        if (this.current_floor > floor_number){
            this.moveDown(floor_number);
        }
        else if (this.current_floor < floor_number){
            this.moveUp(floor_number);
        }
        else {
            this.OpenDoor();
        }
    }
    moveDown(floor_number) {
        console.log ("Elevator is going down");
        this.direction = 'down';
        this.status = 'Moving';
        let interval = setInterval(() => {
            this.current_floor = this.current_floor - 1
            console.log(this.current_floor)
            if (this.current_floor == floor_number) {
                clearInterval(interval)
                console.log("Arrived at floor " + this.current_floor)
                this.OpenDoor()
            }
        }, 1000)
    }

    moveUp(floor_number) {
        console.log ("Elevator is going up");
        this.direction = 'up';
        this.status = 'Moving';
        let interval = setInterval(() => {
            this.current_floor = this.current_floor + 1
            console.log(this.current_floor)
            if (this.current_floor == floor_number) {
                clearInterval(interval)
                console.log("Arrived at floor " + this.current_floor)
                this.OpenDoor()
            }
        }, 1000)
    }
    addFloorToList(floor_number){
        this.floor_list.push(floor_number);
        if (this.direction == "Up"){
            this.floor_list.sort();
            console.log(this.floor_list)
        }
        else if (this.direction == "Down"){
         this.floor_list.sort().reverse();
           console.log(this.floor_list)
        }
    }

    OpenDoor(){
        console.log("Opening door on floor " + this.current_floor)
        this.status = 'open_door';
        setTimeout(() => {
          this.closeDoor()
        }, 5000);
    }

    closeDoor(){
        console.log("Closing door");
        this.status = 'close_door';
        if (this.floor_list.length > 0) {
            this.move_next()
        }
    }
    activateInsideButton(floor_number) {
        console.log ("Activated button at floor " + floor_number);
        if  (this.request_floor == this.floor_list){
            this.activate_InsideButton = false;
            }
        if (this.request_floor < this.floor_list){
            this.moveUp();
            }
        else if (this.request_floor > this.floor_list){
            this.moveDown();
            }
    }
    
    
}
const a = new ElevatorController(10,2);

//scenario 1
a.column.elevatorList[0].current_floor = 1;
a.column.elevatorList[1].current_floor = 5;
a.RequestElevator(2, 'Up')
a.RequestFloor(a.column.elevatorList[0], 6)


//scenario 2
//a.column.elevatorList[0].current_floor = 9;
//a.column.elevatorList[1].current_floor = 2;

//a.RequestElevator(0, 'Up')
//a.RequestFloor(a.column.elevatorList[1], 5)

//a.RequestElevator(2, 'Up')
//a.RequestFloor(a.column.elevatorList[1], 4)

//a.RequestElevator(8, 'Down')
//a.RequestFloor(a.column.elevatorList[0], 1)

//Scenario 3
// a.column.elevatorList[0].current_floor = 9;
// a.column.elevatorList[1].current_floor = 2;
//a.RequestElevator(9, 'Down')
//a.RequestFloor(a.column.elevatorList[0], 2)
//a.RequestElevator(2, 'Down')
//a.RequestFloor(a.column.elevatorList[1], 1)