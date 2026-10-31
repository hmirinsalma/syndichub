# SyndicHub - Phases Détaillées avec Tâches

Ce document liste **toutes les tâches à faire pour chaque phase** du projet SyndicHub.

---

## ✅ Phase 0 - Initialisation (3 jours) - **TERMINÉE**

**Date limite** : 22 octobre 2026  
**Statut** : ✅ **100% complète**

### Tâches réalisées :

1. ✅ Créer le dépôt GitHub `syndichub`
2. ✅ Configurer les 42 labels GitHub
3. ✅ Créer les 12 milestones
4. ✅ Configurer la protection de la branche `main`
5. ✅ Créer la branche `develop`
6. ✅ Ajouter README.md initial
7. ✅ Ajouter LICENSE (MIT)
8. ✅ Configurer .gitignore
9. ✅ Créer docs/github-setup-guide.md
10. ✅ Créer .github/ISSUE_TEMPLATE/
11. ✅ Créer structure des dossiers
12. ✅ Pousser vers GitHub
13. ✅ Créer tag v0.1.0
14. ✅ Fermer milestone Phase 0

---

## ✅ Phase 1 - Fondations (5 jours) - **TERMINÉE**

**Date limite** : 27 octobre 2026  
**Statut** : ✅ **100% complète**

### Tâches réalisées :

1. ✅ Créer solution backend avec 5 projets .NET
2. ✅ Configurer Clean Architecture (dépendances correctes)
3. ✅ Créer projet frontend React + TypeScript + Vite
4. ✅ Configurer Tailwind CSS
5. ✅ Créer docker-compose.yml (SQL Server + MailHog)
6. ✅ Ajouter ApiResponse dans Shared
7. ✅ Configurer Swagger dans API
8. ✅ Créer endpoint /api/v1/health
9. ✅ Tester Docker (SQL Server accessible)
10. ✅ Vérifier frontend build
11. ✅ Pousser vers GitHub
12. ✅ Créer tag v0.2.0

---

## ✅ Phase 2 - Base de données (4 jours) - **TERMINÉE**

**Date limite** : 31 octobre 2026  
**Statut** : ✅ **100% complète**

### Tâches réalisées :

1. ✅ Créer entités : User, Residence, Building, Unit
2. ✅ Configurer DbContext avec EF Core
3. ✅ Ajouter propriétés communes (CreatedAt, UpdatedAt, IsDeleted)
4. ✅ Configurer Fluent API pour les relations
5. ✅ Créer migration InitialCreate
6. ✅ Appliquer migration dans SQL Server
7. ✅ Vérifier dans SSMS (5 tables créées)
8. ✅ Ajouter __EFMigrationsHistory
9. ✅ Documenter le schéma de base de données
10. ✅ Pousser vers GitHub
11. ✅ Créer tag v0.3.0

---

## ✅ Phase 3 - Authentification (6 jours) - **TERMINÉE**

**Date limite** : 6 novembre 2026  
**Statut** : ✅ **100% complète**

### Tâches réalisées :

1. ✅ Modifier User pour hériter de IdentityUser<Guid>
2. ✅ Configurer ASP.NET Core Identity
3. ✅ Ajouter JwtSettings dans appsettings.json
4. ✅ Créer AuthService (register, login, generate JWT)
5. ✅ Créer DTOs : RegisterRequest, LoginRequest, AuthResponse
6. ✅ Créer AuthController (POST register, login)
7. ✅ Créer migration AddIdentityTables
8. ✅ Appliquer migration (10 tables Identity)
9. ✅ Tester dans Postman (register Admin, Syndic, Resident)
10. ✅ Tester login avec JWT
11. ✅ Exporter collection Postman
12. ✅ Pousser vers GitHub + tag v0.4.0

---

## 🔵 Phase 4 - Résidences et lots (6 jours) - **EN COURS**

**Date limite** : 12 novembre 2026  
**Statut** : 🔵 **0% complète**

### Objectif :
Permettre au SYNDIC de créer des résidences, immeubles, lots et d'inviter des résidents.

### Tâches à faire :

1. ⬜ Créer ResidenceService + interface
2. ⬜ Créer DTOs : CreateResidenceDto, ResidenceDto, BuildingDto, UnitDto
3. ⬜ Créer ResidenceController (CRUD résidences)
4. ⬜ Ajouter autorisation [Authorize(Roles = "SYNDIC, ADMIN")]
5. ⬜ Créer BuildingController (CRUD immeubles)
6. ⬜ Créer UnitController (CRUD lots)
7. ⬜ Ajouter filtre global EF Core sur residence_id (isolation multi-tenant)
8. ⬜ Tester dans Postman (créer résidence, immeuble, 3 lots)
9. ⬜ Vérifier dans SSMS (données insérées)
10. ⬜ Créer InvitationService (génération de lien d'invitation)
11. ⬜ Tester invitation d'un résident
12. ⬜ Pousser vers GitHub + tag v0.5.0

**Ce que vous allez apprendre** :
- Autorisation par rôle (JWT claims)
- Filtres globaux EF Core (multi-tenant)
- Relations entre entités (Residence → Building → Unit)

---

## ⬜ Phase 5 - Paiements (10 jours)

**Date limite** : 22 novembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Gérer les appels de fonds, paiements, soldes et impayés.

### Tâches à faire :

1. ⬜ Créer entités : ChargeCall, Installment, Payment
2. ⬜ Créer migration AddPaymentsTables
3. ⬜ Créer ChargeCallService (créer appel de fonds)
4. ⬜ Implémenter répartition par tantièmes
5. ⬜ Créer DTOs : CreateChargeCallDto, InstallmentDto, PaymentDto
6. ⬜ Créer ChargeCallController (CRUD appels de fonds)
7. ⬜ Créer PaymentService (enregistrer paiement)
8. ⬜ Implémenter imputation FIFO (First In First Out)
9. ⬜ Calculer solde d'un lot
10. ⬜ Créer PaymentController (POST /payments)
11. ⬜ Gérer les statuts (PENDING, PARTIAL, PAID, OVERDUE)
12. ⬜ Tester dans Postman (créer appel de fonds, enregistrer paiement)
13. ⬜ Vérifier calculs dans SSMS
14. ⬜ Ajouter validation FluentValidation
15. ⬜ Gérer concurrence (RowVersion sur Payment)
16. ⬜ Créer endpoint GET /units/{id}/balance
17. ⬜ Créer endpoint GET /units/{id}/installments
18. ⬜ Pousser vers GitHub + tag v0.6.0

**Ce que vous allez apprendre** :
- Logique métier complexe (répartition, imputation FIFO)
- Transactions de base de données
- Gestion de la concurrence
- Validation avec FluentValidation

---

## ⬜ Phase 6 - Documents PDF (5 jours)

**Date limite** : 27 novembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Générer des reçus PDF automatiques et des relevés de compte.

### Tâches à faire :

1. ⬜ Créer entité Receipt
2. ⬜ Créer migration AddReceiptTable
3. ⬜ Installer QuestPDF (licence Community)
4. ⬜ Créer PdfService + interface IPdfGenerator
5. ⬜ Implémenter génération reçu PDF (logo, numéro, QR code)
6. ⬜ Créer endpoint POST /receipts/generate
7. ⬜ Stocker PDF dans dossier uploads/
8. ⬜ Créer endpoint GET /receipts/{id}/download
9. ⬜ Tester génération PDF dans Postman
10. ⬜ Ouvrir PDF généré et vérifier (numéro, logo, montant)
11. ⬜ Implémenter relevé de compte PDF
12. ⬜ Pousser vers GitHub + tag v0.7.0

**Ce que vous allez apprendre** :
- Génération de PDF avec QuestPDF
- Stockage de fichiers
- Téléchargement de fichiers via API

---

## ⬜ Phase 7 - Tickets (7 jours)

**Date limite** : 4 décembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Système de réclamation (pannes, problèmes) avec photos et commentaires.

### Tâches à faire :

1. ⬜ Créer entités : Ticket, TicketComment
2. ⬜ Créer migration AddTicketsTables
3. ⬜ Créer TicketService
4. ⬜ Créer DTOs : CreateTicketDto, TicketDto, CommentDto
5. ⬜ Créer TicketController (CRUD tickets)
6. ⬜ Implémenter upload de photos (max 3 photos/ticket)
7. ⬜ Créer endpoint POST /tickets/{id}/comments
8. ⬜ Gérer statuts (OPEN, IN_PROGRESS, RESOLVED, CLOSED)
9. ⬜ Ajouter autorisation (RESIDENT peut créer, SYNDIC peut tout voir)
10. ⬜ Tester dans Postman (créer ticket, ajouter commentaire)
11. ⬜ Vérifier dans SSMS
12. ⬜ Créer endpoint GET /tickets (filtres par statut)
13. ⬜ Pousser vers GitHub + tag v0.8.0

**Ce que vous allez apprendre** :
- Upload de fichiers (images)
- Relations avec commentaires (1-N)
- Gestion des statuts et transitions

---

## ⬜ Phase 8 - Communication (8 jours)

**Date limite** : 12 décembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Annonces officielles + notifications par email.

### Tâches à faire :

1. ⬜ Créer entité Announcement
2. ⬜ Créer migration AddAnnouncementTable
3. ⬜ Créer AnnouncementService
4. ⬜ Créer DTOs : CreateAnnouncementDto, AnnouncementDto
5. ⬜ Créer AnnouncementController (CRUD annonces)
6. ⬜ Ajouter autorisation (seul SYNDIC peut créer)
7. ⬜ Installer MailKit
8. ⬜ Créer EmailService + interface IEmailSender
9. ⬜ Configurer SMTP (MailHog en dev)
10. ⬜ Envoyer email automatique à tous les résidents lors d'une annonce
11. ⬜ Tester dans Postman (créer annonce)
12. ⬜ Vérifier email dans MailHog (http://localhost:8025)
13. ⬜ Créer template HTML pour les emails
14. ⬜ Ajouter relances automatiques (Hangfire)
15. ⬜ Pousher vers GitHub + tag v0.9.0

**Ce que vous allez apprendre** :
- Envoi d'emails avec MailKit
- MailHog pour tester les emails en local
- Tâches planifiées avec Hangfire

---

## ⬜ Phase 9 - Dashboard & Audit (6 jours)

**Date limite** : 18 décembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Tableaux de bord + journal d'audit.

### Tâches à faire :

1. ⬜ Créer entité AuditLog
2. ⬜ Créer migration AddAuditLogTable
3. ⬜ Créer AuditService (enregistrer actions)
4. ⬜ Ajouter middleware pour capturer toutes les actions
5. ⬜ Créer endpoint GET /audit-logs (réservé ADMIN)
6. ⬜ Créer DashboardService
7. ⬜ Créer endpoint GET /dashboard/syndic (KPIs : total collecté, impayés, tickets ouverts)
8. ⬜ Créer endpoint GET /dashboard/resident (solde, prochaines échéances)
9. ⬜ Créer entité Expense (dépenses)
10. ⬜ Créer ExpenseController (CRUD dépenses)
11. ⬜ Créer endpoint GET /expenses (liste visible par tous)
12. ⬜ Pousser vers GitHub + tag v0.10.0

**Ce que vous allez apprendre** :
- Middleware ASP.NET Core
- Agrégation de données (KPIs)
- Journal d'audit

---

## ⬜ Phase 10 - CI/CD & Déploiement (10 jours)

**Date limite** : 30 décembre 2026  
**Statut** : ⬜ **0% complète**

### Objectif :
Automatiser les tests et déployer sur internet.

### Tâches à faire :

1. ⬜ Créer tests unitaires (Domain, Application)
2. ⬜ Créer tests d'intégration (API)
3. ⬜ Configurer GitHub Actions (.github/workflows/ci.yml)
4. ⬜ Faire passer les tests en CI
5. ⬜ Choisir plateforme d'hébergement (Render, Railway, Azure)
6. ⬜ Créer base de données PostgreSQL en ligne
7. ⬜ Configurer variables d'environnement
8. ⬜ Déployer le backend
9. ⬜ Déployer le frontend (Vercel ou Netlify)
10. ⬜ Tester l'application en ligne
11. ⬜ Créer compte démo (admin, syndic, resident)
12. ⬜ Pousser vers GitHub + tag v0.11.0

**Ce que vous allez apprendre** :
- Tests avec xUnit
- GitHub Actions (CI/CD)
- Déploiement sur le cloud
- PostgreSQL en production

---

## ⬜ Phase 11 - Finalisation 1.0 (7 jours)

**Date limite** : 6 janvier 2027  
**Statut** : ⬜ **0% complète**

### Objectif :
Polir l'application, documenter et créer la release finale.

### Tâches à faire :

1. ⬜ Créer frontend complet (toutes les pages React)
2. ⬜ Intégrer TanStack Query + Axios
3. ⬜ Créer formulaires avec React Hook Form + Zod
4. ⬜ Ajouter gestion des erreurs frontend
5. ⬜ Créer README.md complet (screenshots, installation, démo)
6. ⬜ Créer CHANGELOG.md
7. ⬜ Créer diagrammes UML finaux
8. ⬜ Enregistrer vidéo démo (2-3 minutes)
9. ⬜ Créer GitHub Release v1.0.0
10. ⬜ Publier lien de démo dans README

**Ce que vous allez apprendre** :
- Architecture frontend complète
- Gestion d'état avec TanStack Query
- Documentation de projet professionnel

---

## 🎯 RÉSUMÉ

| Phase | Nom | Tâches | Durée | Statut |
|-------|-----|--------|-------|--------|
| 0 | Initialisation | 14 | 3j | ✅ Terminée |
| 1 | Fondations | 12 | 5j | ✅ Terminée |
| 2 | Base de données | 10 | 4j | ✅ Terminée |
| 3 | Authentification | 12 | 6j | ✅ Terminée |
| 4 | Résidences | 12 | 6j | 🔵 En cours |
| 5 | Paiements | 18 | 10j | ⬜ À faire |
| 6 | PDF | 12 | 5j | ⬜ À faire |
| 7 | Tickets | 13 | 7j | ⬜ À faire |
| 8 | Communication | 15 | 8j | ⬜ À faire |
| 9 | Dashboard | 12 | 6j | ⬜ À faire |
| 10 | CI/CD | 12 | 10j | ⬜ À faire |
| 11 | Finalisation | 10 | 7j | ⬜ À faire |
| **TOTAL** | **12 phases** | **152 tâches** | **77 jours** | **33% fait** |

---

## 💡 COMMENT UTILISER CE DOCUMENT

### Pour GitHub Issues :

Chaque tâche ci-dessus peut devenir une **GitHub Issue** :

**Exemple** :
- **Titre** : `[P4] Créer ResidenceService + interface`
- **Description** : 
  ```
  ## Objectif
  Créer le service métier pour gérer les résidences.
  
  ## Critères d'acceptation
  - [ ] Interface IResidenceService créée
  - [ ] ResidenceService implémenté
  - [ ] Méthodes : CreateAsync, GetByIdAsync, UpdateAsync, DeleteAsync
  - [ ] Tests unitaires passent
  
  ## Fichiers à créer
  - `backend/src/SyndicHub.Application/Interfaces/IResidenceService.cs`
  - `backend/src/SyndicHub.Application/Services/ResidenceService.cs`
  ```
- **Labels** : `phase:4`, `type:feature`, `module:residence`
- **Milestone** : Phase 4 - Résidences et lots

### Pour suivre votre progression :

1. **Cochez les tâches** dans ce fichier au fur et à mesure
2. **Créez les issues** sur GitHub pour chaque tâche
3. **Fermez les issues** quand vous terminez
4. **Fermez le milestone** quand toutes les tâches de la phase sont faites

---

## 🚀 PROCHAINE ÉTAPE

**Maintenant, on va :**

1. ✅ Corriger les dates des milestones sur GitHub
2. ✅ Créer les issues pour Phase 4 (Résidences)
3. ✅ Commencer Phase 4 demain

**Êtes-vous prête à organiser ça sur GitHub ?** 😊
