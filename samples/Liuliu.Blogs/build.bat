dotnet build

cd src/ui/ng-alain
npm install && npm run-script build && del ..\..\Liuliu.Blogs.Web\wwwroot\* /q && copy dist\* ..\..\Liuliu.Blogs.Web\wwwroot\ && cd ..\..\Liuliu.Blogs.Web && dotnet build -c Release && dotnet publish -c Release && cd ..\..\ && docker build -t liuliu.blogs.web .
