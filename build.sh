data_project=src/NexPay.Data
startup_project=src/NexPay.Api

if [ -z "$1" ]
    then
        echo "Building project"
        dotnet build
    else
        if [ "$1" = "clear" ]; then
            echo "Clearing project binaries"
            rm -rf {src,tests}/*/{bin,obj}
        fi
        if [ "$1" = "restore" ]; then
            echo "Clearing project binaries"
            rm -rf {src,tests}/*/{bin,obj}
            echo "Restoring"
            dotnet restore
        fi
        if [ "$1" = "run" ]; then
            echo "Building and running project"
            dotnet run --project $startup_project
        fi
        if [ "$1" = "test" ]; then
            echo "Running unit tests"
            dotnet test tests/*
        fi
        if [ "$1" = "watch" ] && [ "$2" = "test" ]; then
            dotnet watch --project tests/* test
        fi
        if [ "$1" = "watch" ]; then
            dotnet watch --project $startup_project run
        fi
        if [ "$1" = "database" ] && [ "$2" = "update" ]; then
            dotnet ef database update -s $startup_project --project $data_project
        fi
        if [ "$1" = "migrations" ] && [ "$2" = "add" ]; then
            dotnet ef migrations add $3 -s $startup_project --project $data_project
        fi
        if [ "$1" = "migrations" ] && [ "$2" = "remove" ]; then
            dotnet ef migrations remove -s $startup_project --project $data_project
        fi
        
fi




