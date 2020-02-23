# Advanced Topics

## N input boxes for bulk create
- this is for the example of adding bulk passengers to a ride
- use an array to store new passenger objects (hard coded with 1 at first)
  - ``` ts
      newPassengers: any[] = [
        {
          name: ''
        },
      ]
      ```
- loop over array to display an input box for each passenger in the array
  - ``` html
      <form (submit)="addBulkPassengers()">
        <div *ngFor="let newPassenger of newPassengers; let i = index;">
          <label>Passenger Name: </label>
          <input [(ngModel)]="newPassengers[i].name" name="passenger{{i}}name" type="text">
        </div>
        <button>Add Passenger</button>
      </form>
      ```
- send the array of new passengers in post request
- controller (prob better to use `insertMany()`):
  - ``` js
      createBulk(request, response) {
          console.log(request.params);

          Ride.findById(request.params.rideId)
            .then((ride) => {

              if (ride.passengers.length + request.body.length > ride.capacity) {
                // structure our custom error message the same as validation errors
                // so front end can handle it the same
                response.json({
                  errors: {
                    errors: {
                      capacity: {
                        message: "not enough room to add all passengers."
                      }
                    }
                  }
                });
              }
              else { // capacity not full
                // new Passenger runs Passenger model validations

                for (const passengerInfo of request.body) {
                  ride.passengers.push(new Passenger(passengerInfo));
                }

                ride.save()
                  .then((updatedRide) => {
                    response.json({ ride: updatedRide });
                  })
                  // catch errors that happen from .save
                  .catch((errors) => {
                    response.json({ errors: errors });
                  });
              }
            })
            // catch errors that happen from finding a ride
            .catch((errors) => {
              response.json({ errors: errors });
            });
        },
      ```