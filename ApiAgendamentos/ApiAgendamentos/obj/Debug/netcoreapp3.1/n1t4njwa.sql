  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Agendamento` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Data` datetime NOT NULL,
    `Hora` datetime NOT NULL,
    `Status` text NULL,
    `Id_Cliente` int NOT NULL,
    `Id_Funcionario` int NOT NULL,
    `Id_Empresa` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Empresa` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` text NULL,
    `Cnpj` text NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Estabelecimento` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` text NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Horario` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Inicio` datetime NOT NULL,
    `Fim` datetime NOT NULL,
    `Dia_Semana` text NULL,
    `Id_Empresa` int NOT NULL,
    `Id_Funcionario` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Ocorrencia` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Data` datetime NOT NULL,
    `Descricao` text NULL,
    `Id_Funcionario` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Pessoa` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` text NULL,
    `Cpf` text NULL,
    `Cargo` text NULL,
    `Data_Nascimento` datetime NOT NULL,
    `Estado` text NULL,
    `Cidade` text NULL,
    `Bairro` text NULL,
    `Rua` text NULL,
    `Complemento` text NULL,
    `Numero` int NOT NULL,
    `Telefone1` text NULL,
    `Telefone2` text NULL,
    `Id_Funcionario` int NOT NULL,
    `Id_Estabelecimento` int NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Servico` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` text NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200919232232_initial', '3.1.8');

ALTER TABLE `Pessoa` ADD `ServicoId` int NULL;

ALTER TABLE `Ocorrencia` ADD `PessoaId` int NULL;

ALTER TABLE `Agendamento` ADD `EmpresaId` int NULL;

CREATE TABLE `EstabelecimentosPessoas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `nome` text NULL,
    `EstabelecimentoId` int NULL,
    `PessoaId` int NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_EstabelecimentosPessoas_Estabelecimento_EstabelecimentoId` FOREIGN KEY (`EstabelecimentoId`) REFERENCES `Estabelecimento` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_EstabelecimentosPessoas_Pessoa_PessoaId` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `HorarioEmpresas` (
    `IdHorario` int NOT NULL AUTO_INCREMENT,
    `IdEmpresa` int NOT NULL,
    `IdHorarioNavigationId` int NULL,
    `IdEmpresaNavigationId` int NULL,
    PRIMARY KEY (`IdHorario`),
    CONSTRAINT `FK_HorarioEmpresas_Empresa_IdEmpresaNavigationId` FOREIGN KEY (`IdEmpresaNavigationId`) REFERENCES `Empresa` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_HorarioEmpresas_Horario_IdHorarioNavigationId` FOREIGN KEY (`IdHorarioNavigationId`) REFERENCES `Horario` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `HorarioPessoas` (
    `IdHorario` int NOT NULL AUTO_INCREMENT,
    `IdPessoa` int NOT NULL,
    `IdHorarioNavigationId` int NULL,
    `IdPessoaNavigationId` int NULL,
    PRIMARY KEY (`IdHorario`),
    CONSTRAINT `FK_HorarioPessoas_Horario_IdHorarioNavigationId` FOREIGN KEY (`IdHorarioNavigationId`) REFERENCES `Horario` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_HorarioPessoas_Pessoa_IdPessoaNavigationId` FOREIGN KEY (`IdPessoaNavigationId`) REFERENCES `Pessoa` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `ServicoFuncionarios` (
    `IdServico` int NOT NULL AUTO_INCREMENT,
    `IdPessoa_IdFuncionario` int NOT NULL,
    `IdPessoaNavigationId` int NULL,
    `ServicoId` int NULL,
    PRIMARY KEY (`IdServico`),
    CONSTRAINT `FK_ServicoFuncionarios_Pessoa_IdPessoaNavigationId` FOREIGN KEY (`IdPessoaNavigationId`) REFERENCES `Pessoa` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_ServicoFuncionarios_Servico_ServicoId` FOREIGN KEY (`ServicoId`) REFERENCES `Servico` (`Id`) ON DELETE RESTRICT
);

CREATE INDEX `IX_Pessoa_ServicoId` ON `Pessoa` (`ServicoId`);

CREATE INDEX `IX_Ocorrencia_PessoaId` ON `Ocorrencia` (`PessoaId`);

CREATE INDEX `IX_Agendamento_EmpresaId` ON `Agendamento` (`EmpresaId`);

CREATE INDEX `IX_EstabelecimentosPessoas_EstabelecimentoId` ON `EstabelecimentosPessoas` (`EstabelecimentoId`);

CREATE INDEX `IX_EstabelecimentosPessoas_PessoaId` ON `EstabelecimentosPessoas` (`PessoaId`);

CREATE INDEX `IX_HorarioEmpresas_IdEmpresaNavigationId` ON `HorarioEmpresas` (`IdEmpresaNavigationId`);

CREATE INDEX `IX_HorarioEmpresas_IdHorarioNavigationId` ON `HorarioEmpresas` (`IdHorarioNavigationId`);

CREATE INDEX `IX_HorarioPessoas_IdHorarioNavigationId` ON `HorarioPessoas` (`IdHorarioNavigationId`);

CREATE INDEX `IX_HorarioPessoas_IdPessoaNavigationId` ON `HorarioPessoas` (`IdPessoaNavigationId`);

CREATE INDEX `IX_ServicoFuncionarios_IdPessoaNavigationId` ON `ServicoFuncionarios` (`IdPessoaNavigationId`);

CREATE INDEX `IX_ServicoFuncionarios_ServicoId` ON `ServicoFuncionarios` (`ServicoId`);

ALTER TABLE `Agendamento` ADD CONSTRAINT `FK_Agendamento_Empresa_EmpresaId` FOREIGN KEY (`EmpresaId`) REFERENCES `Empresa` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Ocorrencia` ADD CONSTRAINT `FK_Ocorrencia_Pessoa_PessoaId` FOREIGN KEY (`PessoaId`) REFERENCES `Pessoa` (`Id`) ON DELETE RESTRICT;

ALTER TABLE `Pessoa` ADD CONSTRAINT `FK_Pessoa_Servico_ServicoId` FOREIGN KEY (`ServicoId`) REFERENCES `Servico` (`Id`) ON DELETE RESTRICT;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200923163844_1', '3.1.8');

