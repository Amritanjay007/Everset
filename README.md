                                  COURIER SERVICE HELPER 
  # Introduction:
   •This is a console application for helping courier service operator.
   •This application is helpful for courier service operator in following tasks:
            i. Delivery cost estimation based on the available offers.
            ii.	Delivery time estimation.
    •Delivery cost estimation:
            Delivery cost = (Base Delivery cost + (Package total weight * 10) + (Distance to Destination * 5)) - Discount.
                       *Discount is based on coupon code costumer has given (every coupon contains coupon code, distance up to which offer is applicable and weight up to which offer is applicable).
    •Delivery time estimation:
       Assumptions for calculation:
         i.	Every vehicle has a on limit on maximum weight (kg) that it can carry.
         ii. All Vehicles travel at the same speed and in the same route and it is assumed that all the destinations can be covered in a single route.
        
  # Delivery Criteria:
     i.	Shipment should contain max packages vehicle can carry in a trip.
     ii. We should prefer heavier packages when there are multiple shipments with the same no. of packages.
     iii. If the weights are also the same, preference should be given to the shipment which can be delivered fast.

  # Prerequisites:
     •	Dotnet core 5.0 is required to run this application.
     •	Code editor for editing the code (visual studio code or visual studio) 

  # Steps to run the application:
    i.	Open a command prompt and navigate to the project path.
    ii.	 Do dotnet restore.
    iii. Do dotnet run.
    iv.	In command prompt we will get following option:
          1. Delivery cost estimation
          2. Delivery time and cost estimation
    v.	If we select option 1 then we have to enter following details:
          base delivery cost:
          no of packages:

        And we need to fill the detail of each package like:
        weight in kg:
        Distance in km:
        Offer code:

        Output will be:
                 PakageID:
                 Discount:
                 Total Cost:

    vi.	If we select option 2 then we have to enter following details:
        
                    base delivery cost:
                    no of packages:
                    And we need to fill the detail of each package like:
                         weight in kg:
                         Distance in km:
                         Offer code:
                    Number of vehicles:
                    Max speed:
                    Max carriable Weight:

                    Output will be:
                         PakageID:
                         Discount:
                         Total Cost:
                         Estimated delivery time in hours: 


