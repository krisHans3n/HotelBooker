# HotelBooker

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

