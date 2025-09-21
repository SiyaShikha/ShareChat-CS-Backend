#!/bin/bash

echo "Updating database..."
dotnet ef database update
# dotnet ef database update --project ../ShareChat.csproj

if [ $? -eq 0 ]; then
    echo "Database updated successfully!"
else
    echo "Database update failed!"
fi
