-- --------------------------------------------------------
-- Servidor:                     localhost
-- Versão do servidor:           5.7.19-log - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              9.3.0.4984
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Copiando estrutura para tabela sale_point.categoria
CREATE TABLE IF NOT EXISTS `categoria` (
  `cat_id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `cat_ds_categoria` varchar(50) NOT NULL,
  PRIMARY KEY (`cat_id_categoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sale_point.forma_pagamento
CREATE TABLE IF NOT EXISTS `forma_pagamento` (
  `pgt_id_forma_pagamento` int(11) NOT NULL AUTO_INCREMENT,
  `pgt_ds_forma_pagamento` varchar(50) NOT NULL,
  PRIMARY KEY (`pgt_id_forma_pagamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.


-- Copiando estrutura para tabela sale_point.produto
CREATE TABLE IF NOT EXISTS `produto` (
  `pro_id_produto` int(11) NOT NULL AUTO_INCREMENT,
  `pro_ds_produto` varchar(50) NOT NULL,
  `pro_id_categoria` int(11) NOT NULL,
  `pro_ds_preco` double NOT NULL,
  PRIMARY KEY (`pro_id_produto`),
  KEY `FK_produto_categoria` (`pro_id_categoria`),
  CONSTRAINT `FK_produto_categoria` FOREIGN KEY (`pro_id_categoria`) REFERENCES `categoria` (`cat_id_categoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Exportação de dados foi desmarcado.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
