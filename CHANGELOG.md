# Changelog

Tous les changements notables du projet SyndicHub seront documentés dans ce fichier.

Le format est basé sur [Keep a Changelog](https://keepachangelog.com/fr/1.0.0/),
et ce projet adhère au [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [Non publié]

### Phase 2 - Base de données (2026-10-26)

#### Ajouté

**Entités du domaine**
- `User` : utilisateurs (ADMIN, SYNDIC, RESIDENT) avec rôles et résidence
- `Residence` : copropriétés avec adresse, tantièmes totaux, solde de caisse
- `Building` : immeubles dans une résidence avec nombre d'étages
- `Unit` : lots (appartements, parkings, locaux) avec tantièmes, solde, résident

**Entity Framework Core**
- Installation EF Core 8.0.11 (SqlServer + Design)
- `ApplicationDbContext` avec configuration Fluent API
- Chaîne de connexion vers SQL Server Docker (localhost:1433)
- Configuration des relations (1-N entre Residence-Building-Unit-User)
- Index sur colonnes critiques (Email unique, ResidenceId, IsDeleted)
- Valeurs par défaut SQL (GETUTCDATE pour CreatedAt, 0 pour Balance)
- Suppression logique avec `IsDeleted`

**Migration InitialCreate**
- 5 tables créées : User, Residence, Building, Unit, __EFMigrationsHistory
- Clés étrangères avec CASCADE et RESTRICT selon les règles métier
- Index pour performance des requêtes

#### Testé
- ✅ Connexion à SQL Server Docker via SSMS
- ✅ Base de données SyndicHub créée
- ✅ Migration appliquée avec succès
- ✅ Structure des tables vérifiée dans SSMS
- ✅ Contraintes et relations correctes

---

### Phase 1 - Fondations (2026-10-23)

#### Ajouté

**Backend**
- Structure Clean Architecture avec 5 projets (.NET 8)
  - `SyndicHub.Domain` : entités et règles métier
  - `SyndicHub.Shared` : modèles partagés
  - `SyndicHub.Application` : cas d'usage et interfaces
  - `SyndicHub.Infrastructure` : implémentations (EF Core, JWT, etc.)
  - `SyndicHub.API` : contrôleurs et configuration
- Solution file `backend/SyndicHub.slnx` avec références correctes
- Modèle de réponse standard `ApiResponse<T>` avec timestamp et erreurs
- Modèle de pagination `PaginatedResult<T>`
- Configuration Serilog pour logs structurés
- Configuration Swagger/OpenAPI
- Configuration CORS
- Health endpoint `/api/v1/health`
- docker-compose.yml avec SQL Server (port 1433) et MailHog (ports 1025, 8025)

**Frontend**
- Projet React 18 + TypeScript avec Vite
- Configuration Tailwind CSS
- Installation React Router, Axios
- Page de test de connexion à l'API avec design moderne
- Configuration TypeScript stricte
- Proxy Vite vers l'API backend
- README frontend documenté

**Configuration**
- `.editorconfig` pour cohérence de code
- Configuration ESLint et Prettier pour le frontend
- `.gitignore` excluant `.kiro/` et les fichiers sensibles

#### Testé
- ✅ API backend démarre sur http://localhost:5050
- ✅ Health endpoint retourne un JSON valide
- ✅ Frontend démarre sur http://localhost:3000
- ✅ Frontend se connecte avec succès au backend
- ✅ Build frontend sans erreur

---

## [0.1.0] - Phase 0 - Initialisation (2026-10-22)

#### Ajouté
- Dépôt GitHub `syndichub` créé
- 42 labels GitHub (type, module, priority, phase)
- 12 milestones (Phases 0-11)
- Protection de la branche `main` (PR requise)
- Branche `develop` pour intégration
- README.md avec présentation du projet
- Documentation `docs/github-setup-guide.md`
- Templates d'issues GitHub (bug, feature)
- Structure de dossiers de base

---

## Légende

- **Ajouté** : nouvelles fonctionnalités
- **Modifié** : changements dans des fonctionnalités existantes
- **Déprécié** : fonctionnalités bientôt supprimées
- **Supprimé** : fonctionnalités supprimées
- **Corrigé** : corrections de bugs
- **Sécurité** : en cas de vulnérabilités
