# DEFINITION - VAGRANT
Vagrant.require_version "= 2.0.4"
Vagrant.configure("2") do |co|

# DEFINITION - CONFIGURATION
  co.vm.box = "ubuntu/xenial64"
  co.vm.box_check_update = false
  co.vm.box_version = "20180420.0.0"
  co.vm.hostname = "devbox"
  co.vm.post_up_message = "run 'cd /vagrant' to access the project artifacts."
  co.vm.provision "shell", path: "vagrantup.sh"
  co.vm.synced_folder ".", "/vagrant"

# DEFINITION - NETWORK
  co.vm.network "forwarded_port", guest: 9000, host: 9000, host_ip: "127.0.0.1" 
  co.vm.network "forwarded_port", guest: 9001, host: 9001, host_ip: "127.0.0.1" 
  co.vm.network "forwarded_port", guest: 4200, host: 4200, host_ip: "127.0.0.1" 
  co.vm.network "forwarded_port", guest: 3333, host: 3333, host_ip: "127.0.0.1" 
#  co.vm.network "forwarded_port", guest: 8000, host: 8000, host_ip: "127.0.0.1"
#  co.vm.network "forwarded_port", guest: 4000, host: 4000, host_ip: "127.0.0.1"

# DEFINITION - PROVIDER
  co.vm.provider "virtualbox" do |vb|
    vb.gui = false
    vb.name = "vagrantbox-#{Time.now.to_i}"
    vb.memory = 1024
  end
end
