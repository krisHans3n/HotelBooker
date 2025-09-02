# HotelBooker

A hotel booking API that provides the following actions:
- Find a hotel based on it's name.
- Find available rooms between two dates for a given number of people.
- Book a room.
- Find booking details based on a booking reference.
- Allows clearing data in the database
- Allows seeding data into the database

Extras:
- Allows an over view of guests (for building save model for booking)
- Allows an over view of rooms (for building save model for booking)

Swagger UI is enabled for local developent.

## End-Points Summary
### Booking Endpoints:

GET /api/Booking/:reference

Parameter:
 - reference (string)
 
POST /api/Booking

Parameters:
 ```json
{
  "bookingReference": "string",
  "checkIn": "2025-09-02",
  "checkOut": "2025-09-02",
  "numberOfGuests": 0,
  "roomId": 0,
  "guestId": 0
} 
 ```

### Guest Endpoints:

GET /api/Guest

### Hotel Endpoints:
GET /api/Hotel/:name

parameter:
 - name (string)

### Room Endpoints:
GET /api/Room

GET /api/Room/:available
parameter (available):
  - from (string)
  - to (string)

### Test Endpoints:
GET /api/Test/ResetData

GET /api/Test/SeedData

