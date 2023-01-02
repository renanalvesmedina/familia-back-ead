using Lumini.Common.Model;

namespace Familia.Ead.Application.Utils
{
    public class ErrorCatalog
    {
        public static ErrorCatalogEntry Generic => ("FAMILY-EAD-GEN-01", "Generic Error!");
        public static ErrorCatalogEntry InvalidDocument => ("FAMILY-EAD-GEN-02", "CPF Inválido!");
        public static ErrorCatalogEntry InvalidEmail => ("FAMILY-EAD-GEN-03", "Email inválido!");

        public static class Authentication
        {
            public static ErrorCatalogEntry NotCreated(string desc) => ("FAMILY-AUTHENTICATION-USER-01", desc);
            public static ErrorCatalogEntry AuthenticateError => ("FAMILY-AUTHENTICATION-02", "Falha no login, tente novamente!");
            public static ErrorCatalogEntry NotFoundRoles => ("FAMILY-AUTHENTICATION-USER-03", "Usuário não tem perfil atribuido!");
            public static ErrorCatalogEntry LockoutUser => ("FAMILY-AUTHENTICATION-04", "Usuário bloqueado!");
            public static ErrorCatalogEntry NotAllowedUser => ("FAMILY-AUTHENTICATION-05", "Essa conta não tem permissão para se logar!");
        }

        public static class Course
        {
            public static ErrorCatalogEntry NotFound => ("FAMILY-COURSE-01", "Curso não encontrado.");
            public static ErrorCatalogEntry Exists => ("FAMILY-COURSE-02", "Já existe um curso com este nome.");
            public static ErrorCatalogEntry InvalidName => ("FAMILY-COURSE-03", "Nome do curso inválido.");
        }

        public static class Enrollment
        {
            public static ErrorCatalogEntry NotFound => ("FAMILY-ENROLLMENT-01", "Aluno não matriculado.");
            public static ErrorCatalogEntry ExistsInCourse => ("FAMILY-ENROLLMENT-02", "Aluno já está matriculado neste curso.");
        }
    }
}
