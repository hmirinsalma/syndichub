# Guide de Configuration GitHub - SyndicHub

Ce document vous guide pour configurer les labels, milestones et protections de branche sur GitHub.

---

## 📋 ÉTAPE 1 : Créer les Labels

### URL : https://github.com/hmirinsalma/syndichub/labels

### Labels à créer (cliquez sur "New label" pour chacun)

#### Labels de Phase (couleur bleue : `#0052CC`)

| Nom | Description | Couleur |
|-----|-------------|---------|
| `phase:0` | Phase 0 - Initialisation | `#0052CC` |
| `phase:1` | Phase 1 - Fondations | `#0052CC` |
| `phase:2` | Phase 2 - Base de données | `#0052CC` |
| `phase:3` | Phase 3 - Authentification | `#0052CC` |
| `phase:4` | Phase 4 - Résidences et lots | `#0052CC` |
| `phase:5` | Phase 5 - Paiements | `#0052CC` |
| `phase:6` | Phase 6 - Documents PDF | `#0052CC` |
| `phase:7` | Phase 7 - Tickets | `#0052CC` |
| `phase:8` | Phase 8 - Communication | `#0052CC` |
| `phase:9` | Phase 9 - Dashboard | `#0052CC` |
| `phase:10` | Phase 10 - CI/CD | `#0052CC` |
| `phase:11` | Phase 11 - Release 1.0 | `#0052CC` |

#### Labels de Type (couleurs variées)

| Nom | Description | Couleur |
|-----|-------------|---------|
| `type:feature` | Nouvelle fonctionnalité | `#00A86B` (vert) |
| `type:bug` | Correction de bug | `#D73A4A` (rouge) |
| `type:docs` | Documentation | `#0075CA` (bleu) |
| `type:test` | Tests | `#FBCA04` (jaune) |
| `type:chore` | Maintenance / Configuration | `#EDEDED` (gris) |

#### Labels de Module (couleur violette : `#5319E7`)

| Nom | Description | Couleur |
|-----|-------------|---------|
| `module:auth` | Module Authentification | `#5319E7` |
| `module:residence` | Module Résidences | `#5319E7` |
| `module:resident` | Module Résidents | `#5319E7` |
| `module:charge` | Module Appels de fonds | `#5319E7` |
| `module:payment` | Module Paiements | `#5319E7` |
| `module:receipt` | Module Reçus PDF | `#5319E7` |
| `module:ticket` | Module Tickets | `#5319E7` |
| `module:announcement` | Module Annonces | `#5319E7` |
| `module:expense` | Module Dépenses | `#5319E7` |
| `module:dashboard` | Module Tableaux de bord | `#5319E7` |
| `module:audit` | Module Audit | `#5319E7` |
| `module:notification` | Module Notifications | `#5319E7` |

#### Labels de Priorité (couleurs orangées)

| Nom | Description | Couleur |
|-----|-------------|---------|
| `priority:low` | Priorité basse | `#FBCA04` (jaune) |
| `priority:medium` | Priorité moyenne | `#FFA500` (orange) |
| `priority:high` | Priorité haute | `#FF6347` (rouge-orange) |

---

## 🎯 ÉTAPE 2 : Créer les Milestones

### URL : https://github.com/hmirinsalma/syndichub/milestones

### Milestones à créer (cliquez sur "New milestone" pour chacun)

| Titre | Description | Date limite |
|-------|-------------|-------------|
| **Phase 0 - Initialisation** | Configuration du dépôt et documentation | 22/10/2026 |
| **Phase 1 - Fondations** | Squelette backend et frontend | 27/10/2026 |
| **Phase 2 - Base de données** | Modèle de données et migrations | 31/10/2026 |
| **Phase 3 - Authentification** | JWT, rôles et isolation | 06/11/2026 |
| **Phase 4 - Résidences** | Gestion résidences, lots, résidents | 12/11/2026 |
| **Phase 5 - Paiements** | Appels de fonds et paiements | 22/11/2026 |
| **Phase 6 - Documents PDF** | Génération reçus et relevés | 27/11/2026 |
| **Phase 7 - Tickets** | Système de réclamations | 04/12/2026 |
| **Phase 8 - Communication** | Annonces, dépenses, emails | 12/12/2026 |
| **Phase 9 - Dashboard** | Tableaux de bord et audit | 18/12/2026 |
| **Phase 10 - CI/CD** | Tests et déploiement | 30/12/2026 |
| **Phase 11 - Release 1.0** | Finalisation et release | 06/01/2027 |

**Note** : Les dates sont indicatives, adaptez-les selon votre planning réel.

---

## 🔒 ÉTAPE 3 : Protéger la branche `main`

### URL : https://github.com/hmirinsalma/syndichub/settings/branches

### Actions à faire :

1. Cliquez sur **"Add rule"** ou **"Add branch protection rule"**

2. Dans **"Branch name pattern"**, tapez : `main`

3. **Cochez les options suivantes** :

   ✅ **Require a pull request before merging**
   - ✅ Require approvals (1 approval minimum)
   - ✅ Dismiss stale pull request approvals when new commits are pushed
   
   ✅ **Require status checks to pass before merging** (à activer après la Phase 10 quand la CI sera prête)
   - ⏸️ Pour l'instant, laissez cette option décochée
   
   ✅ **Require conversation resolution before merging**
   
   ✅ **Do not allow bypassing the above settings**

4. Cliquez sur **"Create"** ou **"Save changes"**

### Résultat :
- ❌ Push direct sur `main` interdit
- ✅ Obligation de passer par une Pull Request
- ✅ Vous devez approuver votre propre PR (bonne pratique)

---

## 🌿 ÉTAPE 4 : Créer la branche `develop`

### Option A : Via l'interface GitHub

1. Allez sur : https://github.com/hmirinsalma/syndichub
2. Cliquez sur le menu déroulant des branches (où il y a écrit "main")
3. Tapez `develop` dans le champ de recherche
4. Cliquez sur **"Create branch: develop from main"**

### Option B : Via Git en local (je peux le faire pour vous)

```bash
git checkout -b develop
git push -u origin develop
```

---

## ✅ Vérification finale

Une fois terminé, vous devriez avoir :
- ✅ 30+ labels créés et organisés
- ✅ 12 milestones créés avec dates
- ✅ Branche `main` protégée
- ✅ Branche `develop` créée

---

## 🎓 Pourquoi on fait tout ça ?

### Labels
→ Organiser et filtrer facilement les 100+ issues du projet

### Milestones
→ Suivre visuellement l'avancement de chaque phase (ex : "Phase 5 : 8/18 tâches terminées = 44%")

### Protection de `main`
→ Éviter les erreurs et garder la production toujours stable

### Branche `develop`
→ Tester et intégrer les features avant de les mettre en production

---

## 💡 Conseil pratique

**Pour l'instant**, créez au moins :
- Les labels de phase (phase:0 à phase:11)
- Les labels de type (type:feature, type:bug, etc.)
- Les 3 premiers milestones (Phase 0, 1, 2)

Vous pourrez créer les autres progressivement au besoin.

---

**Note** : Ce fichier est pour votre usage personnel, il est dans le dépôt Git mais n'a pas besoin d'être dans le README principal.