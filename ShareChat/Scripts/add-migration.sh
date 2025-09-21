#!/bin/bash

# Default migration name if none is provided
MIGRATION_NAME=${1:-NewMigration}

if [ "$MIGRATION_NAME" == "NewMigration" ]; then
    echo "No migration name provided. Using default: $MIGRATION_NAME"
fi

echo "Adding migration: $MIGRATION_NAME"
dotnet ef migrations add "$MIGRATION_NAME"
# dotnet ef migrations add "$MIGRATION_NAME" --project ../ShareChat.csproj

if [ $? -eq 0 ]; then
    echo "Migration added successfully. Updating database..."
    dotnet ef database update
    # dotnet ef database update --project ../ShareChat.csproj

    if [ $? -eq 0 ]; then
        echo "Database updated successfully!"
    else
        echo "Database update failed after adding migration."
    fi
else
    echo "Migration failed. Database update skipped."
fi
