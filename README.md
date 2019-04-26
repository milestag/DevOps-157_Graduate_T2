# DevOps-157_Graduate_T2
Graduation Demo For SoftServe IT Academy Team2
Hello, my name is Yuri Ivanisenko, I am a member of the team №2 of the DevOps-157 group Dnipro SoftServe Academy

My colleague Andrey Velichkovsky and I want to introduce you to our graduation project.
the goal of this project is to demonstrate all the knowledge we gained during the course at SoftServe IT Academy
and show how the principle of CI / CD is implemented in practice

The project is an application written in the NET.CORE Framework
using Micrsoft Visual Studio 2017 Community Edition And MS SQL Server

This is a simple 4-page application for students enrolling in Online Courses.
Information about students and their data are stored in the MSSQL database

//Demonstrate the APP Main Page

On the main page we see advertising slides of the technologies used.
	Main menu at the top of the page
	At the bottom of the page under the slider, we see a list of technologies used, software, links to
	the documentation used, as well as links to repositories with all the source files, tutorials and explanations.

The second page contains the Deployment Diagramm, which describes the environment in which the application is deployed
and explanations to the chart

The third page of the application is the contact information of me and my colleague. You See our photos, phone numbers, emails
that you can use to contact us.

The fourth link displays the contents of the database. Demo information about students who are enrolled in a group
DevOps-157 Dnipro
We can add students, delete, edit information about them.


The application does not represent a commercial value and is created simply as a demonstrator of the capabilities of the technologies used.
and techniques in practice.

We now turn to the description of the deployment of the environment and then to the pipeline itself and its components.

To deploy our application after a successful build, we created an environment in Azure Cloud,
which contains such resources:
- Resource group
- Cuburnetes cluster
- Virtual Machines Cluster Nodes based on Ububtu Server 16.04 LTS
- Internal load balancer
- External IP address
- Networked NOD interfaces
- Virtual LAN
- Disks for NOD - for storing information
- Register of containers
- Logging service
	
This environment is created in the pipeline automatically using the ARM templates saved into the repository. 
If the specified resources are not found, they are created anew, and if they exist, only the changes are added without re-creating the resource.
The Pipeline Deployment Method - Incremnetal

Now I want to pay your attention to the Build Pipeline in Azure DevOps
 It consists of 1 Job  and 7 Tasks
 
 First - we get resotces from our Azure Repository 
 Then we start Jobs  with build in Agent Pool - Hosted Ubuntu
 
 - As a result, we got this container.
 - Build Docker Container
 - Push Image to Azure Container Registry
 - Install Helm Package Manager
 - Pack Sample Charts for Helm from repo
 - Copy Arm Templates from Repo as Artifacts for deploy Stage
 - Publish All artifacts 
 

Next We Go to the Release Pipline Which deploy our App to Kubernetes Cluster

It Consists of Artifact Stage and Dev Stage with 1 Job and Some Tasks
- Preserve All needed Tags for Our Cluster
- Creation of Recources From ARM templates in Increment Mode
- Extraction of required parameters from json files
- Setup Tiller to have an afford to work with Cluster
- Set ImagePulLSecrets
- Install Helm at Agent
- Init Helm with admin rights
- Send Our Demo APP to cluster

And we can watch our Application at http://graduatedemo.online
