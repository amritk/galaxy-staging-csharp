# Demo Api Scalar Galaxy C# Reference

## Planets

### Create

```csharp
Create(PlanetCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /planets`
- Summary: Create a planet

### Retrieve

```csharp
Retrieve(PlanetRetrieveParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /planets/{planetId}`
- Summary: Get a planet

### Update

```csharp
Update(PlanetUpdateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `PUT /planets/{planetId}`
- Summary: Update a planet

### List

```csharp
List(PlanetListParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /planets`
- Summary: Get all planets

### Delete

```csharp
Delete(PlanetDeleteParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `DELETE /planets/{planetId}`
- Summary: Delete a planet

### UploadImage

```csharp
UploadImage(PlanetUploadImageParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /planets/{planetId}/image`
- Summary: Upload an image to a planet

## CelestialBodies

### Create

```csharp
Create(CelestialBodyCreateParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /celestial-bodies`
- Summary: Create a celestial body

## Authentication

### CreateToken

```csharp
CreateToken(AuthenticationCreateTokenParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /auth/token`
- Summary: Get a token

### CreateUser

```csharp
CreateUser(AuthenticationCreateUserParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `POST /user/signup`
- Summary: Create a user

### ListMe

```csharp
ListMe(AuthenticationListMeParams parameters, CancellationToken cancellationToken = default)
```

- HTTP: `GET /me`
- Summary: Get authenticated user
