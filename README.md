# ContractManagement
Веб-приложение по управлению договорами.

## Стек технологий:  
### Backend:  
- .NET 7.0  
- EntityFrameworkCore  
- PostgreSQL
- ClosedXML

### Frontend:  
- Angular  
- TypeScrypt  

## Описание приложения
Приложение предназанчено для просмотра данных о договорах и этапах договоров, а также загрузки новых данных в БД из файлов *.xlsx.

### Структура БД:
1. Таблица Contracts (Договоры):
- ContractCode (Шифр договора, тип: text)
- ContractName (Наименование договора, тип: text)
- Client (Заказчик, тип: text)
2. ContractStages (Этапы договора):
- StageName (Наименование этапа, тип: text)
- StartDate (Дата начала, тип: date)
- EndDate (Дата окончания, тип: date)

### Backend:
Обращение к серверной части выполняется по адресу https://localhost:5001 (далее по тексту - localhostback). Имеются следующие конечные точки:
#### 1. [POST] localhostback/Import/UploadFile
Прием файла, проверка на корректность расширения файла (*.xlsx), чтение и проверка структуры файла, а также загрузка данных в БД.

#### 2. [GET] localhostback/api/Contracts/GetContractStages
Предоставление полного перечня контрактов из таблицы Contracts в формате json.

#### 3. [GET] localhostback/api/Contracts/GetContractStages
Предоставление полного перечня этапов контрактов из таблицы ContractStages в формате json.

### Frontend:
Обращение к frontend части выполняется по адресу https://localhost:4200 (далее по тексту - localhostfront). Имеются следующие конечные точки:
#### 1. localhostfront/Contracts/Index
Статичная страница с отображением договоров и их этапов. Стартовая страница.

#### 2. localhostfront/Contracts/Import
Страница с возможностью выбора и загрузки файла с данными на сервер. При загрузке файла выполняется первоначальная проверка формата файла, доступен только *.xlsx. 
Проблемы, возникающие на любом из этапов обработки файла отображаются на странице снизу от строки загрузки файла.
