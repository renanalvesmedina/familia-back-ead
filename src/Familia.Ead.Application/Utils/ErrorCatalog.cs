using Lumini.Common.Model;

namespace Familia.Ead.Application.Utils
{
    public class ErrorCatalog
    {
        public static ErrorCatalogEntry Generic => ("FAMILY-EAD-GEN-00", "Generic Error!");
        public static ErrorCatalogEntry GenericWithMessage(string desc) => ("FAMILY-EAD-GEN-01", desc);
        public static ErrorCatalogEntry InvalidDocument => ("FAMILY-EAD-GEN-02", "CPF Inválido!");
        public static ErrorCatalogEntry InvalidEmail => ("FAMILY-EAD-GEN-03", "Email inválido!");

        public static class Authentication
        {
            public static ErrorCatalogEntry NotCreated(string desc) => ("FAMILY-AUTHENTICATION-USER-00", desc);
            public static ErrorCatalogEntry NotFoundUser => ("FAMILY-AUTHENTICATION-USER-01", "Usuário não encontrado!");
            public static ErrorCatalogEntry AuthenticateError => ("FAMILY-AUTHENTICATION-02", "Falha no login, tente novamente!");
            public static ErrorCatalogEntry NotFoundRoles => ("FAMILY-AUTHENTICATION-USER-03", "Usuário não tem perfil atribuido!");
            public static ErrorCatalogEntry LockoutUser => ("FAMILY-AUTHENTICATION-04", "Usuário bloqueado!");
            public static ErrorCatalogEntry NotAllowedUser => ("FAMILY-AUTHENTICATION-05", "Essa conta não tem permissão para se logar!");
            public static ErrorCatalogEntry InvalidEmail => ("FAMILY-AUTHENTICATION-06", "Utilize um email válido!");
            public static ErrorCatalogEntry InvalidUserName => ("FAMILY-AUTHENTICATION-07", "Nome inválido!");
            public static ErrorCatalogEntry InvalidSexo => ("FAMILY-AUTHENTICATION-08", "Sexo inválido, deve ser prenchido M para Masculino e F para Feminino!");
            public static ErrorCatalogEntry InvalidPhone => ("FAMILY-AUTHENTICATION-09", "Telefone inválido, deve ser prenchido somente os números com DDD, Ex.: 27991920101");
            public static ErrorCatalogEntry InvalidRole => ("FAMILY-AUTHENTICATION-10", "Adicione um perfil válido para o usuário!");
            public static ErrorCatalogEntry ResetPasswordFailed => ("FAMILY-AUTHENTICATION-11", "Erro para resetar senha!");
        }

        public static class User
        {
            public static ErrorCatalogEntry NotEdited(string desc) => ("FAMILY-USER-00", desc);
        }

        public static class Course
        {
            public static ErrorCatalogEntry NotFound => ("FAMILY-COURSE-01", "Curso não encontrado.");
            public static ErrorCatalogEntry Exists => ("FAMILY-COURSE-02", "Já existe um curso com este nome.");
            public static ErrorCatalogEntry InvalidName => ("FAMILY-COURSE-03", "Nome do curso inválido.");
        }

        public static class Class
        {
            public static ErrorCatalogEntry NotFound => ("FAMILY-CLASS-01", "Aula não encontrada.");
            public static ErrorCatalogEntry Exists => ("FAMILY-CLASS-02", "Já existe uma aula com este nome.");
            public static ErrorCatalogEntry InvalidName => ("FAMILY-CLASS-03", "Nome da aula inválida.");
        }

        public static class Enrollment
        {
            public static ErrorCatalogEntry NotFound => ("FAMILY-ENROLLMENT-01", "Aluno não matriculado.");
            public static ErrorCatalogEntry ExistsInCourse => ("FAMILY-ENROLLMENT-02", "Aluno já está matriculado neste curso.");
        }
    }
}
