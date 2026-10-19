# Guide Docker pour SyndicHub - Pour débutants

Ce guide vous explique Docker simplement et vous guide pour l'utiliser avec SyndicHub.

---

## 🐋 C'est quoi Docker ?

### Analogie simple : Docker = Conteneur de transport maritime

Imaginez que votre application est une marchandise à transporter :
- **Sans Docker** : vous devez installer manuellement SQL Server, configurer les ports, créer la base, gérer les versions... et ça marche sur votre PC mais pas sur le PC de quelqu'un d'autre.
- **Avec Docker** : vous mettez tout dans un "conteneur" standardisé qui marche partout de la même façon.

### En résumé
- **Docker** = plateforme pour créer et exécuter des conteneurs
- **Conteneur** = boîte isolée qui contient une application et tout ce dont elle a besoin
- **Image** = le modèle pour créer un conteneur (comme une photo ISO pour installer Windows)

---

## 🎯 Pourquoi on utilise Docker pour SyndicHub ?

### Sans Docker (la galère) :
1. Installer SQL Server sur Windows (2 Go à télécharger)
2. Créer une instance
3. Configurer les ports
4. Créer un utilisateur et une base de données
5. **Problème** : Si vous changez de PC ou travaillez en équipe, il faut tout refaire !

### Avec Docker (simple) :
1. Une seule commande : `docker compose up`
2. Docker télécharge et lance SQL Server automatiquement
3. La base de données est créée automatiquement
4. **Avantage** : Sur n'importe quel PC avec Docker, ça marche pareil !

---

## 📦 Ce qu'on va avoir avec Docker

Pour SyndicHub, on va utiliser Docker pour lancer **3 conteneurs** :

```
┌─────────────────────────────────────────┐
│  VOTRE ORDINATEUR                       │
│                                         │
│  ┌──────────────┐  ┌─────────────┐     │
│  │ Conteneur 1  │  │ Conteneur 2 │     │
│  │ SQL Server   │  │ MailHog     │     │
│  │ (base de     │  │ (emails de  │     │
│  │  données)    │  │  test)      │     │
│  │ Port: 1433   │  │ Port: 1025  │     │
│  └──────────────┘  └─────────────┘     │
│                                         │
│  🖥️ Backend .NET      🌐 Frontend React │
│  (tourne en local)   (tourne en local) │
│                                         │
└─────────────────────────────────────────┘
```

### Conteneur 1 : SQL Server
- **Rôle** : Base de données du projet
- **Port** : 1433 (port standard SQL Server)
- **Données** : Stockées dans un volume Docker (persistent même si vous arrêtez le conteneur)

### Conteneur 2 : MailHog (en développement)
- **Rôle** : "Faux" serveur email pour tester l'envoi d'emails sans les envoyer vraiment
- **Port SMTP** : 1025 (le backend envoie des emails ici)
- **Interface web** : http://localhost:8025 (voir les emails interceptés)
- **Pourquoi ?** : Vous pouvez tester les invitations, reçus, relances sans spammer de vrais emails

---

## 🛠️ Installation de Docker

### Étape 1 : Télécharger Docker Desktop

1. Allez sur : https://www.docker.com/products/docker-desktop/
2. Téléchargez **Docker Desktop for Windows**
3. Installez-le (l'installation peut demander un redémarrage)

### Étape 2 : Vérifier l'installation

Ouvrez PowerShell et tapez :
```bash
docker --version
```

Vous devriez voir quelque chose comme :
```
Docker version 24.0.6, build xyz
```

Si ça fonctionne, Docker est bien installé ! ✅

---

## 📝 Le fichier `docker-compose.yml`

C'est un fichier de configuration qui dit à Docker **quels conteneurs lancer et comment**.

### Structure du fichier (à créer en Phase 1) :

```yaml
version: '3.8'

services:
  # Conteneur 1 : SQL Server
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2019-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=VotreMotDePasseSecurise123!
      - MSSQL_PID=Developer
    ports:
      - "1433:1433"
    volumes:
      - sqldata:/var/opt/mssql

  # Conteneur 2 : MailHog (emails de test)
  mailhog:
    image: mailhog/mailhog:latest
    ports:
      - "1025:1025"  # SMTP
      - "8025:8025"  # Interface web

volumes:
  sqldata:
```

**Explication ligne par ligne** :

- `services:` → Liste des conteneurs à lancer
- `sqlserver:` → Nom du conteneur SQL Server
- `image:` → L'image Docker à utiliser (téléchargée automatiquement)
- `environment:` → Variables d'environnement (mot de passe, licence, etc.)
- `ports:` → "1433:1433" signifie "le port 1433 du conteneur est accessible sur le port 1433 de votre PC"
- `volumes:` → Dossier pour sauvegarder les données (la base de données persiste même si vous arrêtez Docker)

---

## 🚀 Commandes Docker de base

### Lancer tous les conteneurs
```bash
docker compose up
```
→ Lance SQL Server et MailHog. Vous verrez les logs défiler dans le terminal.

### Lancer en arrière-plan (mode détaché)
```bash
docker compose up -d
```
→ Lance les conteneurs en arrière-plan. Vous récupérez votre terminal.

### Voir les conteneurs en cours d'exécution
```bash
docker ps
```
→ Affiche la liste des conteneurs actifs avec leur statut.

### Arrêter tous les conteneurs
```bash
docker compose down
```
→ Arrête et supprime les conteneurs (mais les données dans les volumes restent).

### Voir les logs d'un conteneur
```bash
docker compose logs sqlserver
docker compose logs mailhog
```

### Supprimer TOUT (conteneurs + volumes)
```bash
docker compose down -v
```
⚠️ **ATTENTION** : Cela supprime aussi les données de la base de données !

---

## 🧪 Comment tester que ça marche ?

### Test 1 : SQL Server

1. Lancez Docker :
   ```bash
   docker compose up -d
   ```

2. Attendez 10-15 secondes (SQL Server met un peu de temps à démarrer)

3. Vérifiez avec :
   ```bash
   docker ps
   ```
   Vous devriez voir `sqlserver` avec le statut "Up"

4. Connectez-vous avec **SQL Server Management Studio (SSMS)** ou **Azure Data Studio** :
   - **Serveur** : `localhost,1433`
   - **Authentification** : SQL Server
   - **Login** : `sa`
   - **Mot de passe** : `VotreMotDePasseSecurise123!`

### Test 2 : MailHog

1. Ouvrez votre navigateur

2. Allez sur : http://localhost:8025

3. Vous devriez voir l'interface MailHog (vide pour l'instant)

4. Quand le backend enverra un email, il apparaîtra ici !

---

## 🗂️ SQL Server : Ce que vous devez savoir

### Vous N'AVEZ PAS BESOIN d'installer SQL Server manuellement !

Docker s'occupe de tout. Voici ce qui se passe :

1. **Phase 2** : On crée les migrations EF Core (fichiers C# qui décrivent la structure de la base)
2. On lance la commande :
   ```bash
   dotnet ef database update
   ```
3. EF Core se connecte à SQL Server (dans Docker) et crée automatiquement :
   - La base `SyndicHubDB`
   - Toutes les tables (User, Residence, Payment, etc.)
   - Les contraintes et index

### Vous n'aurez rien à faire manuellement dans SQL Server !

L'**unique chose** que vous ferez :
- Vérifier que les tables sont bien créées (avec SSMS ou Azure Data Studio)

---

## 🎓 Workflow typique avec Docker

### Au début de chaque session de travail :
```bash
# Lancer les conteneurs
docker compose up -d

# Vérifier qu'ils tournent
docker ps
```

### Pendant le développement :
- Votre backend .NET se connecte à `localhost:1433` (SQL Server)
- Votre backend envoie des emails à `localhost:1025` (MailHog)
- Vous consultez les emails sur http://localhost:8025

### À la fin de la session :
```bash
# Arrêter les conteneurs
docker compose down
```

### Si vous voulez repartir de zéro (base vide) :
```bash
# Supprimer tout (conteneurs + données)
docker compose down -v

# Relancer
docker compose up -d

# Recréer la base de données
cd backend/src/SyndicHub.API
dotnet ef database update
```

---

## 🆘 Problèmes courants et solutions

### Erreur : "port 1433 is already in use"
→ Vous avez déjà SQL Server installé localement qui écoute sur le port 1433.

**Solution** :
- Arrêtez le service SQL Server local dans Windows
- OU changez le port dans `docker-compose.yml` : `"1434:1433"` et adaptez la chaîne de connexion

### Erreur : "Cannot connect to Docker daemon"
→ Docker Desktop n'est pas démarré.

**Solution** : Ouvrez Docker Desktop et attendez qu'il soit prêt.

### Le conteneur SQL Server redémarre en boucle
→ Le mot de passe ne respecte pas les exigences de complexité.

**Solution** : Utilisez un mot de passe fort (8+ caractères, majuscules, minuscules, chiffres, symboles).

### Je ne vois rien dans MailHog
→ Le backend n'a pas encore envoyé d'email.

**Solution** : Testez avec l'endpoint d'invitation d'un résident (Phase 4) ou de connexion (Phase 3).

---

## 📚 Ressources pour apprendre Docker

- **Documentation officielle** : https://docs.docker.com/
- **Tutoriel interactif** : https://www.docker.com/101-tutorial/
- **Vidéo YouTube** : "Docker en 100 secondes" (Fireship)

---

## ✅ Checklist avant la Phase 2

- [ ] Docker Desktop est installé
- [ ] La commande `docker --version` fonctionne
- [ ] Vous comprenez ce qu'est un conteneur et une image
- [ ] Vous savez lancer `docker compose up` et `docker compose down`
- [ ] Vous avez testé d'accéder à http://localhost:8025 (MailHog)

---

**Note** : Ne vous inquiétez pas, je vous guiderai à chaque étape quand on arrivera à Docker !
