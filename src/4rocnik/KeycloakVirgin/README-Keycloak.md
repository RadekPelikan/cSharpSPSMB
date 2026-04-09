# Keycloak Setup

## Quick Start

1. Start Keycloak and PostgreSQL:
   ```bash
   docker-compose up -d
   ```

2. Access Keycloak Admin Console:
   - URL: http://localhost:8080
   - Username: `admin`
   - Password: `admin`

3. Stop services:
   ```bash
   docker-compose down
   ```

4. Stop and remove volumes (clean slate):
   ```bash
   docker-compose down -v
   ```

## Initial Configuration

After starting Keycloak, you'll need to:

1. **Create a Realm**
   - Login to admin console
   - Click "Create Realm"
   - Name it (e.g., "myrealm")

2. **Create a Client**
   - Go to Clients → Create
   - Client ID: your-app-name
   - Client Protocol: openid-connect
   - Access Type: confidential (for backend) or public (for frontend)
   - Valid Redirect URIs: `https://localhost:5001/*` (adjust for your app)

3. **Create Users**
   - Go to Users → Add user
   - Set username, email
   - Go to Credentials tab → Set password

## Environment Variables

Default credentials (change for production):
- Keycloak Admin: `admin` / `admin`
- PostgreSQL: `keycloak` / `keycloak`

## Ports

- Keycloak: `8080`
- PostgreSQL: `5432`

## Notes

- Keycloak is running in development mode (`start-dev`)
- For production, use `start` command and configure proper TLS certificates
- Database data persists in Docker volume `postgres_data`
