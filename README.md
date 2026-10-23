# SyndicHub

> Plateforme web de gestion de syndic de copropriété

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18-61DAFB?logo=react)](https://reactjs.org/)

---

## 📋 À propos

**SyndicHub** est une plateforme web moderne qui remplace les outils archaïques (cahier papier, Excel, WhatsApp) utilisés dans la gestion des copropriétés au Maroc.

### Le problème

Dans la majorité des résidences :
- Les paiements sont notés à la main dans un cahier
- Les annonces se perdent dans les groupes WhatsApp
- Les pannes ne sont pas suivies
- Aucune transparence sur l'utilisation des charges
- Pas de preuve officielle de paiement

### La solution

SyndicHub centralise toute la gestion dans une seule plateforme :
- ✅ Appels de fonds et paiements automatisés
- ✅ Reçus PDF officiels et numérotés
- ✅ Suivi des pannes avec tickets et historique
- ✅ Annonces officielles archivées
- ✅ Transparence financière totale
- ✅ Relances automatiques par email

---

## 🎯 Fonctionnalités principales

### Pour le Syndic
- Gestion complète de la résidence (immeubles, lots, résidents)
- Création et publication d'appels de fonds
- Validation des paiements et génération de reçus PDF
- Suivi des impayés et relances automatiques
- Gestion des tickets de réclamation
- Registre des dépenses avec justificatifs
- Tableau de bord avec indicateurs clés

### Pour les Résidents
- Consultation du solde en temps réel
- Déclaration de paiements avec justificatif
- Signalement de pannes avec photos
- Accès aux annonces officielles
- Téléchargement des reçus et relevés de compte
- Consultation des dépenses de la résidence

---

## 🏗️ Architecture

- **Backend** : ASP.NET Core 8 (Clean Architecture)
- **Frontend** : React 18 + TypeScript + Vite
- **Base de données** : SQL Server 2019+
- **Conteneurisation** : Docker + docker-compose

---

## 🚀 Installation et lancement

### Prérequis

- **.NET SDK 8.0+** : [Télécharger ici](https://dotnet.microsoft.com/download)
- **Node.js 18+** et npm : [Télécharger ici](https://nodejs.org/)
- **Docker Desktop** : [Télécharger ici](https://www.docker.com/products/docker-desktop)

### 1. Cloner le dépôt

```bash
git clone https://github.com/hmirinsalma/syndichub.git
cd syndichub
```

### 2. Lancer SQL Server avec Docker

```bash
docker-compose up -d
```

Cela lance :
- **SQL Server** sur le port `1433`
- **MailHog** (emails de test) sur le port `8025`

### 3. Lancer le backend (.NET API)

```bash
cd backend/src/SyndicHub.API
dotnet run
```

L'API sera accessible sur **http://localhost:5050**  
Documentation Swagger : **http://localhost:5050/swagger**

### 4. Lancer le frontend (React)

Dans un **nouveau terminal** :

```bash
cd frontend
npm install
npm run dev
```

L'application sera accessible sur **http://localhost:3000**

---

## 📁 Structure du projet

```
syndichub/
  ├── backend/
  │   └── src/
  │       ├── SyndicHub.Domain/       # Entités et règles métier
  │       ├── SyndicHub.Shared/       # Modèles partagés (ApiResponse)
  │       ├── SyndicHub.Application/  # Cas d'usage et DTO
  │       ├── SyndicHub.Infrastructure/  # EF Core, Identity, JWT
  │       └── SyndicHub.API/          # Contrôleurs et configuration
  ├── frontend/
  │   └── src/
  │       ├── App.tsx                 # Composant principal
  │       └── main.tsx                # Point d'entrée
  ├── docs/              # Documentation et diagrammes
  ├── .kiro/             # Configuration Kiro (steering, specs)
  └── docker-compose.yml # Orchestration Docker
```

---

## 📝 Documentation

- [Cahier des charges](docs/cahier-des-charges/) (à venir)
- [Diagrammes UML](docs/uml/) (à venir)
- [API Documentation](https://syndichub.example.com/swagger) (à venir)

---

## 🗺️ Roadmap

### ✅ Phase 0 - Initialisation
- ✅ Configuration du dépôt GitHub
- ✅ Création des labels (42) et milestones (12)
- ✅ Protection de la branche `main`
- ✅ Documentation de base

### ✅ Phase 1 - Fondations (EN COURS)
- ✅ Structure backend Clean Architecture (5 projets)
- ✅ Configuration Docker (SQL Server + MailHog)
- ✅ Modèle de réponse API standard (`ApiResponse`, `PaginatedResult`)
- ✅ Health endpoint (`/api/v1/health`)
- ✅ Serilog, Swagger, CORS
- ✅ Création du frontend React 18 + TypeScript + Vite
- ✅ Configuration Tailwind CSS
- ✅ Page de test avec connexion à l'API

### 🔲 Phase 2 - Authentification
- Configuration ASP.NET Core Identity
- JWT authentication
- Routes d'authentification

### 🔲 Phases 3-11
- Voir [tasks.md](.kiro/specs/syndichub/tasks.md) pour le plan complet

---

## 🧪 Tests (à venir)

```bash
# Backend
dotnet test

# Frontend
npm run test
```

---

## 🤝 Contribution

Ce projet est un **projet personnel / portfolio** développé par **Salma** (EMSI Casablanca, 2DSI).

---

## 📄 Licence

Ce projet est sous licence [MIT](LICENSE).

---

## 👤 Auteure

**Salma**  
Étudiante en 2ème année DSI - EMSI Casablanca

📧 Email : hmirin.salma27@gmail.com  
🔗 GitHub : [@hmirinsalma](https://github.com/hmirinsalma)

---

**Note** : Ce projet est en cours de développement actif. La démo en ligne sera disponible prochainement.
