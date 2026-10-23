# SyndicHub Frontend

Interface web de la plateforme SyndicHub, construite avec React 18, TypeScript et Tailwind CSS.

## 🚀 Démarrage rapide

### Prérequis

- Node.js 18+ et npm
- L'API backend doit être lancée sur http://localhost:5050

### Installation

```bash
npm install
```

### Lancement en développement

```bash
npm run dev
```

L'application sera accessible sur **http://localhost:3000**

### Build de production

```bash
npm run build
```

Les fichiers de production seront dans le dossier `dist/`.

## 📁 Structure du projet

```
src/
  app/              # Configuration des routes et providers
  features/         # Modules fonctionnels (auth, charges, payments, etc.)
  components/       # Composants réutilisables
  lib/              # Client API, utilitaires
  locales/          # Traductions (fr.json)
```

## 🛠 Technologies

- **React 18** : Framework UI
- **TypeScript** : Typage statique
- **Vite** : Build tool ultra-rapide
- **Tailwind CSS** : Framework CSS utility-first
- **React Router** : Routage
- **Axios** : Client HTTP
- **React Hook Form** : Gestion des formulaires
- **TanStack Query** : Gestion du state serveur
- **Zod** : Validation des schémas

## 🌐 Variables d'environnement

Créez un fichier `.env.local` basé sur `.env.example` :

```bash
VITE_API_URL=http://localhost:5050
```

## 📝 Conventions

- Composants : PascalCase (ex : `LoginForm.tsx`)
- Hooks : préfixe `use` (ex : `useAuth.ts`)
- Fonctions utilitaires : camelCase (ex : `formatDate.ts`)
- Types : PascalCase avec suffixe `Props` ou `Type`

## 🧪 Tests

```bash
npm run test
```

## 📖 Documentation

Voir la [documentation principale](../README.md) à la racine du projet.
