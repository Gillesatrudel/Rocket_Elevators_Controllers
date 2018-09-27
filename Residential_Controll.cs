using System;
namespace demoApp 
{
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
    }
