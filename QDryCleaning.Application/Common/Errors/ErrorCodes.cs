namespace QDryClean.Application.Common.Errors
{
    public static class ErrorCodes
    {
        // --- Общие / бизнес / валидация ---
        public const int BadRequest = 1000;         // Общая ошибка запроса
        public const int NotFound = 1001;           // Сущность не найдена
        public const int AlreadyExists = 1002;      // Сущность уже существует
        public const int ValidationError = 1003;    // Ошибка валидации
        public const int Conflict = 1004;           // Конфликт состояния (например, нельзя удалить активный заказ)

        // --- Авторизация / доступ ---
        public const int Unauthorized = 2000;       // Пользователь не авторизован (нет токена / токен невалиден)
        public const int Forbidden = 2001;          // Пользователь авторизован, но нет прав
        public const int InvalidLoginOrPassword = 2002; // Неправильный логин/пароль
        public const int TokenExpired = 2003;       // Токен истек
        public const int InvalidToken = 2004;       // Некорректный токен

        // --- Сервер / инфраструктура ---
        public const int InternalServerError = 3000; // Неожиданная ошибка на сервере
        public const int ServiceUnavailable = 3001;  // Сервис временно недоступен
        public const int Timeout = 3002;             // Таймаут запроса к сервису/БД
    }
}