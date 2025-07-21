Machine Monitoring API

## How to Run
1. Clone the repo
2. Run 'dotnet run' from root folder
3. Swagger UI available at 'http://localhost:5199/swagger/index.html'

## Endpoints
- 'POST /api/machines' – Register a machine
- 'POST /api/machines/{id}/status' – Log status
- 'GET /api/machines' – Summary
- 'GET /api/machines/{id}' – Detailed machine info

## Notes
- In-memory storage for simplicity. In production, this would be replaced by a database.
- Machine ID is a 'Guid'.
- Status options: 'Idle' - 0, 'Running' -1, 'Error' -2, 'Maintenance' - 3
