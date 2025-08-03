'use client';

import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';
import {
  TextInput,
  Select,
  NumberInput,
  Textarea,
  Button,
  Group,
  Grid,
  Stack,
} from '@mantine/core';
import { notifications } from '@mantine/notifications';

interface Asset {
  id: string;
  name: string;
  type: string;
  category: string;
  vendor: string;
  model: string;
  serialNumber: string;
  purchaseDate: string;
  warrantyExpiry: string;
  location: string;
  status: string;
  assignedTo: string;
  cost: number;
  maintenanceSchedule: string;
  lastMaintenanceDate: string;
  nextMaintenanceDate: string;
  specifications: Record<string, any>;
  notes: string;
  maintenanceHistory: any[];
  riskLevel: string;
  installationDate: string;
  expectedLifespan: string;
  ipAddress: string;
  macAddress: string;
}

const assetSchema = z.object({
  name: z.string().min(1, 'Name is required'),
  type: z.string().min(1, 'Type is required'),
  vendor: z.string().min(1, 'Vendor is required'),
  model: z.string().min(1, 'Model is required'),
  serialNumber: z.string().min(1, 'Serial number is required'),
  ipAddress: z.string().optional(),
  macAddress: z.string().optional(),
  cost: z.number().min(0, 'Cost must be a positive number'),
  location: z.string().min(1, 'Location is required'),
  status: z.string().min(1, 'Status is required'),
  notes: z.string().optional(),
});

type AssetFormData = z.infer<typeof assetSchema>;

interface EditAssetFormProps {
  asset: Asset;
  onSave: (data: AssetFormData) => void;
  onCancel: () => void;
}

export function EditAssetForm({ asset, onSave, onCancel }: EditAssetFormProps) {
  const {
    register,
    handleSubmit,
    formState: { errors },
    setValue,
    watch,
  } = useForm<AssetFormData>({
    resolver: zodResolver(assetSchema),
    defaultValues: {
      name: asset.name,
      type: asset.type,
      vendor: asset.vendor,
      model: asset.model,
      serialNumber: asset.serialNumber,
      ipAddress: asset.ipAddress,
      macAddress: asset.macAddress,
      cost: asset.cost,
      location: asset.location,
      status: asset.status,
      notes: asset.notes,
    },
  });

  const onSubmit = (data: AssetFormData) => {
    try {
      onSave(data);
      notifications.show({
        title: 'Success',
        message: 'Asset updated successfully',
        color: 'green',
      });
    } catch (error) {
      notifications.show({
        title: 'Error',
        message: 'Failed to update asset',
        color: 'red',
      });
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Stack gap="md">
        <Grid>
          <Grid.Col span={4}>
            <TextInput
              label="Name"
              placeholder="Enter asset name"
              error={errors.name?.message}
              {...register('name')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <Select
              label="Type"
              placeholder="Select asset type"
              data={[
                { value: 'Network Equipment', label: 'Network Equipment' },
                { value: 'Computing Equipment', label: 'Computing Equipment' },
                { value: 'Client Equipment', label: 'Client Equipment' },
              ]}
              error={errors.type?.message}
              value={watch('type')}
              onChange={(value) => setValue('type', value || '')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <TextInput
              label="Vendor"
              placeholder="Enter vendor name"
              error={errors.vendor?.message}
              {...register('vendor')}
            />
          </Grid.Col>
        </Grid>

        <Grid>
          <Grid.Col span={4}>
            <TextInput
              label="Model"
              placeholder="Enter model number"
              error={errors.model?.message}
              {...register('model')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <TextInput
              label="Serial Number"
              placeholder="Enter serial number"
              error={errors.serialNumber?.message}
              {...register('serialNumber')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <NumberInput
              label="Cost"
              placeholder="Enter cost"
              error={errors.cost?.message}
              value={watch('cost')}
              onChange={(value) => setValue('cost', Number(value))}
            />
          </Grid.Col>
        </Grid>

        <Grid>
          <Grid.Col span={4}>
            <TextInput
              label="IP Address"
              placeholder="Enter IP address"
              error={errors.ipAddress?.message}
              {...register('ipAddress')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <TextInput
              label="MAC Address"
              placeholder="Enter MAC address"
              error={errors.macAddress?.message}
              {...register('macAddress')}
            />
          </Grid.Col>
          <Grid.Col span={4}>
            <TextInput
              label="Location"
              placeholder="Enter location"
              error={errors.location?.message}
              {...register('location')}
            />
          </Grid.Col>
        </Grid>

        <Grid>
          <Grid.Col span={4}>
            <Select
              label="Status"
              placeholder="Select status"
              data={[
                { value: 'active', label: 'Active' },
                { value: 'inactive', label: 'Inactive' },
                { value: 'maintenance', label: 'Maintenance' },
              ]}
              error={errors.status?.message}
              value={watch('status')}
              onChange={(value) => setValue('status', value || '')}
            />
          </Grid.Col>
          <Grid.Col span={8}>
            <Textarea
              label="Notes"
              placeholder="Enter additional notes"
              error={errors.notes?.message}
              {...register('notes')}
            />
          </Grid.Col>
        </Grid>

        <Group justify="flex-end" mt="md">
          <Button variant="light" onClick={onCancel}>
            Cancel
          </Button>
          <Button type="submit">
            Save Changes
          </Button>
        </Group>
      </Stack>
    </form>
  );
} 