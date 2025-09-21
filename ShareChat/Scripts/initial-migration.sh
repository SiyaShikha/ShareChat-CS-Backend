#!/bin/bash

echo "Creating initial migration..."
dotnet ef migrations add InitialCreate
# dotnet ef migrations add InitialCreate --project ../ShareChat.csproj

if [ $? -eq 0 ]; then
    echo "Applying initial migration to database..."
    dotnet ef database update
    # dotnet ef database update --project ../ShareChat.csproj
else
    echo "Initial migration failed!"
fi
